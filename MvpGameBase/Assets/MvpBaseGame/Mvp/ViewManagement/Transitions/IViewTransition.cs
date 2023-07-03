using System;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions
{
    /// <summary>
    /// View transitions.
    /// </summary>
    public interface IViewTransition
    {
        /// <summary>
        /// Transition start logic.
        /// </summary>
        /// <param name="onComplete">Callback which will be invoked when PlayIn complete</param>
        void PlayIn(Action onComplete);
        
        /// <summary>
        /// Transition completion logic.
        /// </summary>
        /// <param name="onComplete">Callback which will be invoked when PlayOut complete</param>
        void PlayOut(Action onComplete);
    }
}