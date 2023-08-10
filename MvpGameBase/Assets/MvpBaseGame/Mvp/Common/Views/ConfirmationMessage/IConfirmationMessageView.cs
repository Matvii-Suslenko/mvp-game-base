using MvpBaseGame.Mvp.ViewManagement.Core;
using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage
{
    public interface IConfirmationMessageView : IScreenBaseView
    {
        /// <summary>
        /// Fires on Confirm Button Clicked
        /// </summary>
        event Action ConfirmClicked;
        
        /// <summary>
        /// Fires on Cancel Button Clicked
        /// </summary>
        event Action CancelClicked;
    }
}