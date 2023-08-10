using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Data;
using System.Collections.Generic;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Focus
{
    public interface IViewLayerFocusHandler
    {
        /// <summary>
        /// Fires on Focus Refreshed
        /// </summary>
        event Action<IViewLayerInfo> FocusRefreshed;
        
        /// <summary>
        /// Sets Layers
        /// </summary>
        /// <param name="layers"></param>
        void SetLayers(IEnumerable<IMutableViewLayer> layers);
        
        /// <summary>
        /// True if View Creating is In Progress
        /// </summary>
        bool IsCreatingViewInProgress { get; set; }
        
        /// <summary>
        /// Set all layers unfocused.
        /// </summary>
        void UnfocusAll();
        
        /// <summary>
        /// Determine highest layer that could be focused and focus it.
        /// </summary>
        void RefreshFocus();
        
        /// <summary>
        /// Disabled Focus Updating
        /// </summary>
        /// <param name="isDisabled">True if Is Disabled</param>
        void DisableFocusUpdating(bool isDisabled);
    }
}
