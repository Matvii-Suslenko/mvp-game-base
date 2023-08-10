using MvpBaseGame.Utils.CoroutineRunner.Impl;
using MvpBaseGame.Mvp.ViewManagement.Focus;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Utils.CoroutineRunner;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Factories.Impl
{
    public class CloseUpperViewsCreateViewStrategy : ICreateViewStrategy
    {
        private bool IsCreateViewInProgress
        {
            get => _isCreateViewInProgress;
            set
            {
                _isCreateViewInProgress = value;
                _viewLayerFocusHandler.IsCreatingViewInProgress = value;
            }
        }
        
        private Queue<IViewData> _creatingQueue = new Queue<IViewData>();
        private bool _isCreateViewInProgress;
        private IMutableViewLayer[] _layers;
        private int _openViewLayerIndex;
        private IViewData _viewData;
        
        private readonly IViewLayerFocusHandler _viewLayerFocusHandler;
        private readonly ICoroutineRunner _coroutineRunner;
        

        public CloseUpperViewsCreateViewStrategy(
            ICoroutineRunner coroutineRunner, 
            IViewLayerFocusHandler viewLayerFocusHandler
            )
        {
            _coroutineRunner = coroutineRunner;
            _viewLayerFocusHandler = viewLayerFocusHandler;
        }
        
        public IViewListener CreateView(IViewData viewData, IMutableViewLayer[] layers)
        {
            _layers = layers;
            
            if (IsCreateViewInProgress)
            {
                _creatingQueue.Enqueue(viewData);
            }
            else
            {
                ProcessView(viewData);
            }
            
            return viewData.ViewListener;
        }

        private void ProcessView(IViewData viewData)
        {
            var currentLayer = _layers.FirstOrDefault(layer => viewData.ViewDefinition.LayerId == layer.LayerInfo.LayerId);
            if (currentLayer == null)
            {
                throw new KeyNotFoundException($"Layer {viewData.ViewDefinition.LayerId} not found!");
            }
            
            _viewData = viewData;
            _openViewLayerIndex = Array.IndexOf(_layers, currentLayer);
            
            IsCreateViewInProgress = true;

            _viewLayerFocusHandler.UnfocusAll();

            _coroutineRunner.AfterFrame(() =>
            {
                CheckLayer(_layers, _layers.Length - 1);
            });
        }
        
        private void CheckLayer(IMutableViewLayer[] layers, int currentLayerIndex)
        {
            if (currentLayerIndex == _openViewLayerIndex)
            {
                var currentLayer = layers[_openViewLayerIndex];
                
                void OnViewAdded(IViewData viewData)
                {
                    CreateComplete();
                    currentLayer.ViewAdded -= OnViewAdded;
                }
                
                currentLayer.ViewAdded += OnViewAdded;
                currentLayer.CreateView(_viewData);

                return;
            }

            if (currentLayerIndex == 0)
            {
                CreateComplete();
                return;
            }

            var needCloseView = layers[currentLayerIndex].HasView;
            var isNetworkLossView = currentLayerIndex == _layers.Length - 1;
            
            if(isNetworkLossView)
            {
                CheckLayer(layers, currentLayerIndex - 1);
                return;
            }
            
            if (needCloseView)
            {
                layers[currentLayerIndex].CurrentView.CloseView(() =>
                {
                    layers[currentLayerIndex].ClearLayer();
                    CheckLayer(layers, currentLayerIndex - 1);
                });
            }
            else
            {
                layers[currentLayerIndex].ClearLayer();
                CheckLayer(layers, currentLayerIndex - 1);
            }
        }

        private void CreateComplete()
        {
            IsCreateViewInProgress = false;
            _viewLayerFocusHandler.RefreshFocus();
            
            if (_creatingQueue.Count > 0)
            {
                ProcessView(_creatingQueue.Dequeue());
            }
        }
        
        private IMutableViewLayer GetTopLayer()
        {
            for (int i = _layers.Length - 1; i >= 0; i--)
            {
                if (_layers[i].CurrentView != null)
                {
                    return _layers[i];
                }
            }

            return null;
        }
    }
}