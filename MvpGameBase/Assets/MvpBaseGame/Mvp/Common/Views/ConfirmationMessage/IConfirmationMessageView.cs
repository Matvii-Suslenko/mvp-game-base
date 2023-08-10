using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage
{
    public interface IConfirmationMessageView : IPopupBaseView
    {
        /// <summary>
        /// Fires on Confirm Button Clicked
        /// </summary>
        event Action ConfirmClicked;
    }
}