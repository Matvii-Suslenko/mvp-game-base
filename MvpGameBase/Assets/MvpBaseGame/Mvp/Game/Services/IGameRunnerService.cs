using System;

namespace MvpBaseGame.Mvp.Game.Services
{
    public interface IGameRunnerService : IDisposable
    {
        /// <summary>
        /// Starts Game Run
        /// </summary>
        void StartRun();
    }
}
