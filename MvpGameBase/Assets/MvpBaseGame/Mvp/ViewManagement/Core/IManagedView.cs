using System;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Transitions;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    /// <summary>
    /// Base view functionality.
    /// </summary>
    public interface IManagedView
    {
        /// <summary>
        /// Current view.
        /// </summary>
        GameObject Current { get; }
        
        /// <summary>
        /// Transition signals for stage of the layer lifecycle. 
        /// </summary>
        ITransitionHandler Transition { get; }
        
        /// <summary>
        /// Returns definition data of the view.
        /// </summary>
        IViewDefinition ViewDef { get; }
        
        /// <summary>
        /// Returns whether the view is interactable or not.
        /// </summary>
        bool IsInteractable { get; }

        /// <summary>
        /// Changes the view's interactable state.
        /// </summary>
        /// <param name="isInteractable">True if interactable; otherwise false.</param>
        void SetInteractable(bool isInteractable);
        
        /// <summary>
        /// Closes the view and raises the PlayOutStarted, PlayOutCompleted transition events, and the ViewClosed view event.
        /// </summary>
        /// <param name="onCompleted">The callback action will be executed when PlayOutCompleted event is invoked</param>
        void CloseView(Action onCompleted = null);
    }
}