using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Common.Views.PausedPopup
{
    public interface IPausedPopupView : IPopupBaseView
    {
        /// <summary>
        /// Fires on Back To Lobby Button Clicked
        /// </summary>
        event Action BackToLobbyClicked;
    }
}