using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;

namespace MvpBaseGame.Mvp.Common.Views.SettingsPopup
{
    public class SettingsPopupPresenter : Presenter<ISettingsPopupView>
    {
        public SettingsPopupPresenter(ISettingsPopupView view) : base(view)
        {
        }

        public override void Initialize()
        {
            View.CloseClicked += OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            View.SetInteractable(false);
            View.CloseView();
        }

        public override void Dispose()
        {
            View.CloseClicked -= OnCloseClicked;
        }
    }
}
