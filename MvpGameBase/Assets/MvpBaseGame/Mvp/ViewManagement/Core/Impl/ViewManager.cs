using System;
using System.Collections.Generic;
using System.Linq;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Data.Impl;
using MvpBaseGame.Mvp.ViewManagement.Factories;
using MvpBaseGame.Mvp.ViewManagement.Focus;
using MvpBaseGame.Mvp.ViewManagement.History;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class ViewManager : IViewManager
    {
        public IEnumerable<IViewLayer> Layers => _layers;
        private readonly IMutableViewLayer[] _layers;
        private readonly ICreateViewStrategy _createViewStrategy;
        private readonly IViewLayerHistoryHandler _viewLayerHistoryHandler;
        
        public ViewManager(
            IViewLayersFactory layersFactory, 
            IViewLayerHistoryHandler viewLayerHistoryHandler, 
            IViewLayerFocusHandler viewLayerFocusHandler,
            ICreateViewStrategy createViewStrategy)
        {
            _viewLayerHistoryHandler = viewLayerHistoryHandler;
            _layers = layersFactory.Create();
            
            viewLayerHistoryHandler.SetLayers(_layers);
            viewLayerFocusHandler.SetLayers(_layers);
            _createViewStrategy = createViewStrategy;
        }

        public IViewListener OpenView(IViewDefinition viewDef)
        {
            return CreateView(new ViewData(viewDef));
        }
        
        public IViewListener OpenView<T>(IViewDefinition viewDef, T payload)
        {
            return CreateView(new ViewData(viewDef, payload));
        }

        public IViewListener OpenPreviousView()
        {
            var topView = GetViewInFocus();
            if (topView == null)
            {
                throw new SystemException("No any views on the layer");
            }
            return OpenPreviousView(topView);
        }

        public IViewListener OpenPreviousView(IManagedView view)
        {
            var data = _viewLayerHistoryHandler.GetPrevious(view.ViewDef);
            if (data != null)
            {
                return CreateView(data);
            }
                
            view.CloseView();
            return null;    //TODO: return view listener
        }

        public void ClearHistoryLayer(string layerId)
        {
            _viewLayerHistoryHandler.Clear(layerId);
        }

        protected virtual IViewListener CreateView(IViewData data)
        {
            return _createViewStrategy.CreateView(data, _layers);
        }

        public IManagedView GetView(IViewDefinition viewDef)
        {
            var layer = _layers.FirstOrDefault(l => l.CurrentView?.ViewDef.ViewId == viewDef.ViewId);
            return layer?.CurrentView;
        }

        public bool IsViewOpened(IViewDefinition viewDef)
        {
            return GetView(viewDef) != null;
        }

        public virtual IManagedView GetViewInFocus()
        {
            return GetLayerInFocus()?.CurrentView;
        }
        
        private IViewLayer GetLayerInFocus()
        {
            return _layers.FirstOrDefault(l => l.HasFocus);
        }

        public IViewLayer GetLayer(string layerId)
        {
            return GetLayerById(layerId);
        }

        private IMutableViewLayer GetLayerById(string layerId)
        {
            var layer = _layers.FirstOrDefault(x => x.LayerInfo.LayerId == layerId);

            if (layer == null)
            {
                throw new KeyNotFoundException($"Layer with id: {layerId} not found");
            }

            return layer;
        }
    }
}