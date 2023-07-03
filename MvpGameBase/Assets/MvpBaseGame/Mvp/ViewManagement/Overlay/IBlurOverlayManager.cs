namespace MvpBaseGame.Mvp.ViewManagement.Overlay
{
    public interface IBlurOverlayManager
    {
        /// <summary>
        /// Starts blur overlay displaying on specific layer
        /// </summary>
        /// <param name="layerId"></param>
        /// <param name="customAlpha"></param>
        /// <param name="customFadeDuration"></param>
        void Show(string layerId, float? customAlpha = null, float? customFadeDuration = null);
        
        /// <summary>
        ///  Hides blur over layer when view is closed 
        /// </summary>
        void Hide();
        
        /// <summary>
        /// Immediately hides blur over layer
        /// </summary>
        void HideImmediately();
    }
}