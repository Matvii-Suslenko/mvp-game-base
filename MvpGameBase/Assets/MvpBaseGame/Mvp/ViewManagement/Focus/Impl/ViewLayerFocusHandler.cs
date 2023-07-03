using System;
using System.Collections.Generic;
using System.Linq;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Focus.Impl
{
    public class ViewLayerFocusHandler : IViewLayerFocusHandler
    {
        public event Action<IViewLayerInfo> FocusRefreshed;
        
        private IEnumerable<IMutableViewLayer> _layers;
        public void SetLayers(IEnumerable<IMutableViewLayer> layers)
        {
            _layers = layers;
            
            foreach (var layer in _layers)
            {
                layer.ViewAdded += OnViewAdded;
                layer.AllViewsRemoved += OnAllViewsRemoved;
            }

            RefreshFocus();
        }

        private void OnAllViewsRemoved()
        {
            RefreshFocus();
        }

        private void OnViewAdded(IViewData viewData)
        {
            RefreshFocus();
        }

        private void RefreshFocus()
        {
            IViewLayerInfo focusedLayer = null;
            foreach (var layer in _layers.Reverse())
            {
                if (layer.LayerInfo.IsFocusIgnored)
                {
                    continue;
                }
                
                if (layer.HasView && focusedLayer == null)
                {
                    layer.SetFocus(true);
                    focusedLayer = layer.LayerInfo;
                }
                else
                {
                    layer.SetFocus(false);
                }
            }
            
            FocusRefreshed?.Invoke(focusedLayer);
        }
    }
}