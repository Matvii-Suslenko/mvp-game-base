using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Data;
using System;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public interface ITaskPopupView : IScreenBaseView
    {
        /// <summary>
        /// Fires on Button Clicked with Option Index
        /// </summary>
        event Action<int> OptionClicked;
        
        /// <summary>
        /// Sets Game Task Info
        /// </summary>
        /// <param name="gameTask">Game Task Info</param>
        void SetGameTask(IGameTask gameTask);
    }
}
