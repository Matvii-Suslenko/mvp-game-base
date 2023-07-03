using System;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    /// <summary>
    /// Events and data of base functionality of the layer.
    /// </summary>
    public interface IViewLayer
    {
        /// <summary>
        /// Occurs before the creation of the view.
        /// </summary>
        event Action AddViewStarted;
        
        /// <summary>
        /// Fires when the current view has been set.
        /// </summary>
        event Action<IViewData> ViewAdded;
        
        /// <summary>
        /// Fires when the view starts to be removed.
        /// </summary>
        event Action RemoveViewStarted;
        
        /// <summary>
        ///  Fires when the current view is removed. Returns layerId
        /// </summary>
        event Action<IViewData> ViewRemoved;    
        
        /// <summary>
        /// Fires when all views have been removed.
        /// </summary>
        event Action AllViewsRemoved;
        
        /// <summary>
        /// Triggers when the focus changed
        /// </summary>
        event Action<bool> FocusChanged;
        
        /// <summary>
        /// Returns LayerInfo of the current layer
        /// </summary>
        IViewLayerInfo LayerInfo { get; }
        
        /// <summary>
        /// Returns current view on this layer
        /// </summary>
        IManagedView CurrentView { get; }
        
        /// <summary>
        /// Returns true if the current layer is in focus, otherwise false.
        /// </summary>
        bool HasFocus { get; }

        /// <summary>
        /// Returns true if layer has view or view creating in progress
        /// </summary>
        bool HasView { get; }
        
        /// <summary>
        /// Returns true if layer has next view which is pending to be opened
        /// </summary>
        bool HasNextViewInQueue { get; }

        /// <summary>
        /// Destroys the opened view and clear related resources.
        /// </summary>
        void ClearLayer();
    }
}