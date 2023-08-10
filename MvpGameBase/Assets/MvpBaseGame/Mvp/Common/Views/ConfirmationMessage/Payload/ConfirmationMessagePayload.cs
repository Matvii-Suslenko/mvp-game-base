using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload
{
    public class ConfirmationMessagePayload : IConfirmationMessagePayload
    {
        public Action OnConfirm { get; }
        public Action OnCancel { get; }

        public ConfirmationMessagePayload(Action onConfirm, Action onCancel = null)
        {
            OnConfirm = onConfirm;
            OnCancel = onCancel;
        }
    }
}
