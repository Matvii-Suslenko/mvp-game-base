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

        /// <summary>
        /// Stops Game Run
        /// </summary>
        void StopRun();

        /// <summary>
        /// Moves Pencil
        /// </summary>
        /// <param name="horizontalMovement">Horizontal Movement Value</param>
        void MovePencil(float horizontalMovement);

        /// <summary>
        /// Resets Pencil Position
        /// </summary>
        void ResetPencilPosition();

        /// <summary>
        /// Heals Pencil
        /// </summary>
        void HealPencil();
    }
}
