using System;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Factories;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class ViewLayer : IMutableViewLayer
    {
        public event Action<IViewData> ViewAdded;
        public event Action AddViewStarted;
        public event Action RemoveViewStarted;
        public event Action<IViewData> ViewRemoved;
        public event Action AllViewsRemoved;
        public event Action<bool> FocusChanged;

        public bool HasView => CurrentView != null || _isInstantiatingInProgress;
        public IViewLayerInfo LayerInfo => _viewLayerInfo;
        public IManagedView CurrentView => _currentView;
        public bool HasFocus { get; private set; }
        public bool HasNextViewInQueue => _nextViewData != null;

        private readonly IViewLayerInfo _viewLayerInfo;
        private readonly IViewProvider _viewProvider;
        private IMutableManagedView _currentView;
        private IViewData _nextViewData;
        private bool _isInstantiatingInProgress;
        
        public ViewLayer(IViewLayerInfo viewLayerInfo, IViewProvider viewProvider)
        {
            _viewLayerInfo = viewLayerInfo;
            _viewProvider = viewProvider;
        }
        
        public void CreateView(IViewData data)
        {
            if (_currentView == null)
            {
                _nextViewData = null;
                if (_isInstantiatingInProgress)
                {
                    throw new SystemException(
                        $"[View Manager] Instantiating view for layer: {_viewLayerInfo.LayerId} already in progress");
                }
                
                _isInstantiatingInProgress = true;
                AddViewStarted?.Invoke();
                _viewProvider.Instantiate(data, _viewLayerInfo.LayerTransform).Then(view =>
                {
                    _isInstantiatingInProgress = false;
                    SetView(view, data);
                }).Fail(ex=>
                {
                    _isInstantiatingInProgress = false;
                    data.ViewListener.ViewOpened.ReportFail(ex);
                });
            }
            else
            {
                _nextViewData = data;
                _currentView.CloseView();
            }
        }

        private void SetView(IMutableManagedView view, IViewData data)
        {
            _currentView = view;
            _currentView.Transition.PlayOutStarted += OnStartCloseView;
            _currentView.Transition.PlayInCompleted += OnViewOpened;
            _currentView.ViewClosed += OnViewClosed;
            view.SetData(data);
            ViewAdded?.Invoke(_currentView.Data);
            view.StartTransitionIn();
        }

        private void OnViewOpened()
        {
            _currentView.Data.ViewListener.ViewOpened.Dispatch();
        }
        
        private void DestroyCurrentView()
        {
            var currentView = _currentView;
            _currentView = null;
            var data = currentView.Data;
            currentView.Transition.PlayOutStarted -= OnStartCloseView;
            currentView.ViewClosed -= OnViewClosed;
            _viewProvider.Destroy(currentView);
            currentView.Data.ViewListener.ViewClosed.Dispatch();
            ViewRemoved?.Invoke(data);
        }

        private void OpenNext()
        {
            if (HasNextViewInQueue)
            {
                CreateView(_nextViewData);
            }
        }
        
        public void SetFocus(bool hasFocus)
        {
            _currentView?.SetFocus(hasFocus);
            
            if (HasFocus != hasFocus)
            {
                HasFocus = hasFocus;
                FocusChanged?.Invoke(HasFocus);
            }
        }

        private void OnStartCloseView()
        {
            RemoveViewStarted?.Invoke();
        }

        private void OnViewClosed()
        {
            DestroyCurrentView();
            OpenNext();
            
            if (!HasView)
            {
                LayerCleared();
            }
        }

        public void ClearLayer()
        {
            if (_currentView != null)
            {
                DestroyCurrentView();
                LayerCleared();
            }
        }

        private void LayerCleared()
        {
            AllViewsRemoved?.Invoke();
        }
    }
}
