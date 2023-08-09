using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Services;

namespace MvpBaseGame.Mvp.Common.Views.PausedPopup
{
    public class PausedPopupPresenter : Presenter<IPausedPopupView>
    {
        private readonly IGameRunnerService _gameRunnerService;
        private readonly IViewManager _viewManager;

        public PausedPopupPresenter(
            IGameRunnerService gameRunnerService,
            IViewManager viewManager,
            IPausedPopupView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
            _viewManager = viewManager;
        }

        public override void Initialize()
        {
            View.BackToLobbyClicked += OnBackToLobbyClicked;
            View.CloseClicked += OnCloseClicked;
        }

        private void OnBackToLobbyClicked()
        {
            _gameRunnerService.StopRun();
            _viewManager.OpenView(ViewNames.Lobby);
        }

        private void OnCloseClicked()
        {
            _gameRunnerService.ResumeRun();
            View.SetInteractable(false);
            View.CloseView();
        }

        public override void Dispose()
        {
            View.BackToLobbyClicked += OnBackToLobbyClicked;
            View.CloseClicked -= OnCloseClicked;
        }
    }
}
