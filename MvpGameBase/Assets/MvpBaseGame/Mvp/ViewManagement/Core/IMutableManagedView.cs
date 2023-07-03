using System;
using MvpBaseGame.Mvp.ViewManagement.Data;

namespace MvpBaseGame.Mvp.ViewManagement.Core
{
    /// <summary>
    /// Mutable extension of IManagedView.
    /// </summary>
    public interface IMutableManagedView : IManagedView
    {
        IViewData Data { get; }

        /// <summary>
        /// Determines whether the current view has focus or not, and raises an event on set.
        /// </summary>
        bool HasFocus { get; }

        /// <summary>
        /// Initialises the view with data
        /// </summary>
        /// <param name="data">View data</param>
        void SetData(IViewData data);
        
        /// <summary>
        /// Sets view focus state
        /// </summary>
        /// <param name="hasFocus">true - is view in focus</param>
        void SetFocus(bool hasFocus);
       
        /// <summary>
        /// Starts TransitionIn animation
        /// </summary>
        void StartTransitionIn();

        /// <summary>
        /// Gets the signal when view is closed, and all logic is executed
        /// </summary>
        event Action ViewClosed;
    }
}