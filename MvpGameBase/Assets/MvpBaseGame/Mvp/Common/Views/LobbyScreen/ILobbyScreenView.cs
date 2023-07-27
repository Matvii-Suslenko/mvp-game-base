using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public interface ILobbyScreenView : IScreenBaseView
    {
        /// <summary>
        /// Fires on Settings Button Clicked
        /// </summary>
        event Action SettingsClicked;
    }
}