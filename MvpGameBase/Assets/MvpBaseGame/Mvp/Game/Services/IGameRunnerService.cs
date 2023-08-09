using System;

namespace MvpBaseGame.Mvp.Game.Services
{
    public interface IGameRunnerService : IDisposable
    {
        /// <summary>
        /// Starts Game Run
        /// </summary>
        void StartRun();

        /// <summary>
        /// Pauses Game Run
        /// </summary>
        void PauseRun();
        
        /// <summary>
        /// Resumes Game Run
        /// </summary>
        void ResumeRun();
    }
}
