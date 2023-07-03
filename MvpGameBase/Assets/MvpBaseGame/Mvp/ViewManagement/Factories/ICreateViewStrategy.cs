using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Factories
{
    /// <summary>
    /// Strategy defined to extend behavior on CreateView in ViewManager.
    /// </summary>
    public interface ICreateViewStrategy
    {
        /// <summary>
        /// Executed when ViewManager creates View.
        /// </summary>
        /// <param name="viewData">View configuration and listener data.</param>
        /// <param name="layers">Layers Array.</param>
        /// <returns>Open-Close signals for opening View.</returns>
        IViewListener CreateView(IViewData viewData, IMutableViewLayer[] layers);
    }
}