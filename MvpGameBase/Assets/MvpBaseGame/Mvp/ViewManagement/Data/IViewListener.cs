using MvpBaseGame.Promises;

namespace MvpBaseGame.Mvp.ViewManagement.Data
{
    /// <summary>
    /// View signals when opening and closing a view.
    /// </summary>
    public interface IViewListener
    {
        /// <summary>
        /// Gets the view opened signal.
        /// </summary>
        IPromise ViewOpened { get; }
        
        /// <summary>
        /// Gets the view closed signal.
        /// </summary>
        IPromise ViewClosed { get; }
    }
}
