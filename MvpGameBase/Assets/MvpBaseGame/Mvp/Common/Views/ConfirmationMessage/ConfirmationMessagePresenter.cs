using MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage
{
    public class ConfirmationMessagePresenter : Presenter<IConfirmationMessageView>
    {
        private readonly IConfirmationMessagePayload _payload;

        public ConfirmationMessagePresenter(
            IConfirmationMessagePayload payload,
            IConfirmationMessageView view) : base(view)
        {
            _payload = payload;
        }

        public override void Initialize()
        {
            View.ConfirmClicked += OnConfirmClicked;
            View.CancelClicked += OnCancelClicked;
        }

        private void OnConfirmClicked()
        {
            View.CloseView();
            _payload.OnConfirm?.Invoke();
        }

        private void OnCancelClicked()
        {
            View.CloseView();
            _payload.OnCancel?.Invoke();
        }

        public override void Dispose()
        {
            View.ConfirmClicked -= OnConfirmClicked;
            View.CancelClicked -= OnCancelClicked;
        }
    }
}
