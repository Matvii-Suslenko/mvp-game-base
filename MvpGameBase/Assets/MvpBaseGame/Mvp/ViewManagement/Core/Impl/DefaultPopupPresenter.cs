using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class DefaultPopupPresenter : Presenter<IPopupBaseView>
    {
        public DefaultPopupPresenter(IPopupBaseView view) : base(view)
        {
        }

        public override void Initialize()
        {
            View.CloseClicked += OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            View.CloseView();
        }

        public override void Dispose()
        {
            View.CloseClicked -= OnCloseClicked;
        }
    }
}
