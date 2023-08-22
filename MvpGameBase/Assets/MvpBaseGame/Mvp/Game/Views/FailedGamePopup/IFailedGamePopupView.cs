using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Game.Views.FailedGamePopup
{
    public interface IFailedGamePopupView : IScreenBaseView
    {
        /// <summary>
        /// Fires on Finish Game Button Clicked
        /// </summary>
        event Action FinishGameClicked;
        
        /// <summary>
        /// Fires on Watch Ad Button Clicked
        /// </summary>
        event Action WatchAdClicked;
    }
}
