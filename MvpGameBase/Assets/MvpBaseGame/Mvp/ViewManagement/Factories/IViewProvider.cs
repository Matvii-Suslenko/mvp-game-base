using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Promises;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Factories
{
    /// <summary>
    /// View Provider for creating and destroying a view.
    /// </summary>
    public interface IViewProvider
    {
        /// <summary>
        /// Creates a view.
        /// </summary>
        /// <param name="data">View definition and view listener data.</param>
        /// <param name="transform">Transform of an object</param>
        /// <returns>Promise of the view being created. If the object is loaded and created, a resolved promise will be returned, otherwise it will fail.</returns>
        IPromise<IMutableManagedView> Instantiate(IViewData data, Transform transform);
        
        /// <summary>
        /// Destroy an open view on a layer.
        /// </summary>
        /// <param name="view">Opened view instance</param>
        void Destroy(IMutableManagedView view);
    }
}
