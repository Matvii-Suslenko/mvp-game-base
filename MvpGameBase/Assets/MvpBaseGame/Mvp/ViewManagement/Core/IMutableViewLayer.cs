using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    /// <summary>
    /// Mutable extension of IBaseLayer. 
    /// </summary>
    public interface IMutableViewLayer : IViewLayer
    {
        /// <summary>
        /// Create view using view provider implementation
        /// </summary>
        /// <param name="data">View definition and view listener data</param>
        void CreateView(IViewData data);

        /// <summary>
        /// Sets focus to the current view and raises the focus changed event.
        /// </summary>
        /// <param name="hasFocus">Sets the focus or removes it for the current view.</param>
        void SetFocus(bool hasFocus);
    }
}
