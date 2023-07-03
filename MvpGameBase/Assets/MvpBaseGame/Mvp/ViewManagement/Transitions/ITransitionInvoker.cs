using System;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions
{
    /// <summary>
    /// Transition PlayIn and PlayOut to manage some transition events. 
    /// </summary>
    public interface ITransitionInvoker : ITransitionHandler, IDisposable
    {
        /// <summary>
        /// Handles the transition start action, usually when creating a view
        /// </summary>
        void PlayIn();
        
        /// <summary>
        /// Handles the transition complete action, usually when closing a view
        /// </summary>
        /// <param name="onCompleted">Action handled when PlayOut completed</param>
        void PlayOut(Action onCompleted);
    }
}