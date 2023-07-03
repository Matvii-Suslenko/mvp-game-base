using System;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions
{
    /// <summary>
    /// Handle all possible stages of the view lifecycle.
    /// </summary>
    public interface ITransitionHandler
    {
        /// <summary>
        /// Indicates whether the start transition phase has been completed.
        /// </summary>
        bool IsPlayInComplete { get; }

        /// <summary>
        /// Gets the play starting signal to perform some actions on this event.
        /// </summary>
        event Action PlayInStarted;

        /// <summary>
        /// Gets a signal the start of the play transition is complete.
        /// </summary>
        event Action PlayInCompleted;

        /// <summary>
        ///  Gets the signal of the beginning of the play end.
        /// </summary>
        event Action PlayOutStarted;

        /// <summary>
        /// Gets the signal of the end of play.
        /// </summary>
        event Action PlayOutCompleted;
    }
}