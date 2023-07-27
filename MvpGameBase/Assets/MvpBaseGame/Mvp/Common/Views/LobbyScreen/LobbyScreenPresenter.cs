using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public class LobbyScreenPresenter : Presenter<ILobbyScreenView>
    {
        private readonly IViewManager _viewManager;

        public LobbyScreenPresenter(
            ILobbyScreenView view,
            IViewManager viewManager) : base(view)
        {
            _viewManager = viewManager;
        }

        public override void Initialize()
        {
            View.SettingsClicked += OnSettingsClicked;
        }

        private void OnSettingsClicked()
        {
            _viewManager.OpenView(ViewNames.Settings);
        }

        public override void Dispose()
        {
            View.SettingsClicked -= OnSettingsClicked;
        }
    }
}
