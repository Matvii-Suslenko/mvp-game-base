using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Focus.Impl
{
    public class ViewLayerFocusHandler : IViewLayerFocusHandler
    {
        public event Action<IViewLayerInfo> FocusRefreshed;
        public bool IsCreatingViewInProgress { get; set; }

        private IEnumerable<IMutableViewLayer> _layers;
        private IViewLayerInfo _lastFocusedLayer;
        private bool _isFocusUpdateDisabled;
        private bool _focusRefreshing;

        
        public void SetLayers(IEnumerable<IMutableViewLayer> layers)
        {
            _layers = layers;
            
            foreach (var layer in _layers)
            {
                layer.AllViewsRemoved += OnAllViewsRemoved;
            }

            RefreshFocus();
        }

        private void OnAllViewsRemoved()
        {
            if (IsCreatingViewInProgress || _isFocusUpdateDisabled)
            {
                return;
            }
            
            RefreshFocus();
        }

        public void UnfocusAll()
        {
            foreach (var layer in _layers)
            {
                layer.SetFocus(false);
            }
            FocusRefreshed?.Invoke(null);
        }

        public void RefreshFocus()
        {
            var callEventsAtTheEnd = !_focusRefreshing;
            _focusRefreshing = true;
            var focusedLayerFound = false;
            foreach (var layer in _layers.Reverse())
            {
                if (layer.LayerInfo.IsFocusIgnored)
                {
                    continue;
                }
                
                if (layer.HasView && !focusedLayerFound)
                {
                    focusedLayerFound = true;
                    _lastFocusedLayer = layer.LayerInfo;
                    layer.SetFocus(true);
                }
                else
                {
                    layer.SetFocus(false);
                }
            }

            if (callEventsAtTheEnd)
            {
                FocusRefreshed?.Invoke(_lastFocusedLayer);
                _lastFocusedLayer = null;
                _focusRefreshing = false;
            }
        }

        public void DisableFocusUpdating(bool value)
        {
            _isFocusUpdateDisabled = value;
        }
    }
}