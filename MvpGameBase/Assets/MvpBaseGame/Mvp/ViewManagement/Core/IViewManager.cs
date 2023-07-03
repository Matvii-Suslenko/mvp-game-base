using System.Collections.Generic;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.History;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    /// <summary>
    /// View Manager for views and layers management.
    /// </summary>
    public interface IViewManager : IViewManagerHistory
    {
        /// <summary>
        /// Returns all layers
        /// </summary>
        IEnumerable<IViewLayer> Layers { get; }
        
        /// <summary>
        /// Opens view on the registered layer.
        /// If the layer already has another opened view, the current view will be closed and replaced with the new one.
        /// </summary>
        /// <param name="viewDef">View definition of the opening view.</param>
        /// <returns>Provides signals for ViewOpened and ViewClosed events.</returns>
        IViewListener OpenView(IViewDefinition viewDef);
        
        /// <summary>
        /// Opens view with payload on the registered layer.
        /// If the layer already has another opened view, the current view will be closed and replaced with the new one.
        /// </summary>
        /// <param name="viewDef">ViewDefinition of the opening view.</param>
        /// <param name="payload">Passing Payload object to View.</param>
        /// <typeparam name="T">Type of payload.</typeparam>
        /// <returns>Provides signals for ViewOpened and ViewClosed events.</returns>
        IViewListener OpenView<T>(IViewDefinition viewDef, T payload);

        /// <summary>
        /// Get currently open view.
        /// </summary>
        /// <param name="viewDef">ViewDefinition of the open view.</param>
        /// <returns>Current open view object or null if the view wasn't found.</returns>
        IManagedView GetView(IViewDefinition viewDef);
        
        /// <summary>
        /// Get layer by layerId.
        /// </summary>
        /// <param name="layerId">LayerId name</param>
        /// <returns>Registered IViewLayer layer object.</returns>
        /// <exception cref="KeyNotFoundException">If layer not found</exception>
        IViewLayer GetLayer(string layerId);
        
        /// <summary>
        /// Get the view in focus.
        /// The layer which has the highest priority contains the view in focus.
        /// </summary>
        /// <returns>Current view in focus or null if the view wasn't found.</returns>
        IManagedView GetViewInFocus();
        
        /// <summary>
        /// Check if view is open.
        /// </summary>
        /// <param name="viewDef">View definition.</param>
        /// <returns>True if view is open, otherwise false.</returns>
        bool IsViewOpened(IViewDefinition viewDef);
    }
}
