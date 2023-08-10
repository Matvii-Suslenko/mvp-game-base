using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload
{
    public interface IConfirmationMessagePayload
    {
        /// <summary>
        /// Action on Confirm Clicked
        /// </summary>
        Action OnConfirm { get; }

        /// <summary>
        /// Action on Cancel Clicked
        /// </summary>
        Action OnCancel { get; }
    }
}
