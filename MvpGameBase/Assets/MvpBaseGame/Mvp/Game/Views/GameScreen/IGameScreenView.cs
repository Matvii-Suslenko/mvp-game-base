using MvpBaseGame.Mvp.Common.Components.DragZone;
using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Game.Views.GameScreen
{
    public interface IGameScreenView : IScreenBaseView, IOneDimensionalDragZone
    {
        /// <summary>
        /// Fires on Sound Button Clicked
        /// </summary>
        event Action SoundButtonClicked;
        
        /// <summary>
        /// Fires on Pause Button Clicked
        /// </summary>
        event Action PauseButtonClicked;
    }
}
