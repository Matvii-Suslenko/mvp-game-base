using System.Linq;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Focus;
using Zenject;

namespace MvpBaseGame.Mvp.ViewManagement.Overlay.Impl
{
    public class BlurOverlayManager : IBlurOverlayManager, IInitializable
    {
        private readonly IViewLayerFocusHandler _layerFocusHandler;
        private readonly IBlurOverlayView _overlayView;
        private readonly IViewManager _viewManager;

        public BlurOverlayManager(
            IViewLayerFocusHandler layerFocusHandler,
            IBlurOverlayView overlayView,
            IViewManager viewManager)
        {
            _layerFocusHandler = layerFocusHandler;
            _overlayView = overlayView;
            _viewManager = viewManager;
        }

        public void Initialize()
        {
            var layersInfo = _viewManager.Layers.Select(l => l.LayerInfo);
            _overlayView.SetLayers(layersInfo);
            _layerFocusHandler.FocusRefreshed += OnFocusRefreshed;
        }

        private void OnFocusRefreshed(IViewLayerInfo viewLayerInfo)
        {
            if (viewLayerInfo == null)
            {
                return;
            }

            var hasOverlay = false;
            foreach (var layer in _viewManager.Layers.Reverse())
            {
                var currentView = layer.CurrentView;
                if (currentView == null)
                {
                    continue;
                }

                var autoBlurOverlay = currentView.Current.GetComponent<AutoBlurOverlay>();
                if (autoBlurOverlay != null)
                {
                    hasOverlay = true;
                    Show(layer.LayerInfo.LayerId, autoBlurOverlay.CustomAlpha, autoBlurOverlay.CustomFadeDuration);
                    break;
                }
            }

            if (!hasOverlay)
            {
                Hide();
            }
        }

        public void Show(string layerId, float? customAlpha = null, float? customFadeDuration = null)
        {
            _overlayView.Show(layerId, customAlpha, customFadeDuration);
        }

        public void Hide()
        {
            _overlayView.Hide();
        }

        public void HideImmediately()
        {
            _overlayView.Hide(true);
        }
    }
}