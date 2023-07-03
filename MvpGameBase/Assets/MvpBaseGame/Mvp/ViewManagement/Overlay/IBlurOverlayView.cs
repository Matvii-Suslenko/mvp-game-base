using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;

namespace MvpBaseGame.Mvp.ViewManagement.Overlay
{
    public interface IBlurOverlayView
    {
        /// <summary>
        /// Sets current layers
        /// </summary>
        /// <param name="layersConfiguration">layers configurations</param>
        void SetLayers(IEnumerable<IViewLayerInfo> layersConfiguration);
        
        /// <summary>
        /// Starts blur overlay displaying on specific layer
        /// </summary>
        /// <param name="layerId"></param>
        void Show(string layerId, float? customAlpha = null, float? customFadeDuration = null);
        
        /// <summary>
        /// Refresh overlay canvas position
        /// </summary>
        /// <param name="layerId"></param>
        void RefreshOrder(string layerId);
        
        /// <summary>
        /// Hides blur over layer when view is closed
        /// </summary>
        /// <param name="immediate">if true - blur overlay will be hidden without transition </param>
        void Hide(bool immediate = false);
    }
}