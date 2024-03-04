using System;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public interface ITaskOptionButton
    {
        /// <summary>
        /// Fires on Button Clicked with Option Index
        /// </summary>
        event Action<int> ButtonClicked;

        /// <summary>
        /// Sets Option Index
        /// </summary>
        /// <param name="index">Option Index</param>
        void SetIndex(int index);
        
        /// <summary>
        /// Sets Option Text
        /// </summary>
        /// <param name="text">Option Text</param>
        void SetText(string text);

        /// <summary>
        /// Sets Is Interactable
        /// </summary>
        /// <param name="isInteractable">Is Interactable</param>
        void SetInteractable(bool isInteractable);
    }
}
