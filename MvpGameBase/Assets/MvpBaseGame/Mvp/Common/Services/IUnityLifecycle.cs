using System;

namespace MvpBaseGame.Mvp.Common.Services
{
    public interface IUnityLifecycle
    {
        /// <summary>
        /// Fires On Application Update
        /// </summary>
        event Action<float> Updated;
        
        /// <summary>
        /// Fires On Application Start
        /// </summary>
        event Action Started;
        
        /// <summary>
        /// Fires On Application LateUpdate
        /// </summary>
        event Action LateUpdated;
        
        /// <summary>
        /// Fires On Application Quit
        /// </summary>
        event Action Quited;
        
        /// <summary>
        /// Fires On Application Pause
        /// </summary>
        event Action<bool> Paused;
        
        /// <summary>
        /// Fires On Focus Change
        /// </summary>
        event Action<bool> FocusChanged;
    }
}
