using MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Payloads.Impl;
using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Mvp.Game.Services;
using MvpBaseGame.Mvp.Game.Commands;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Common.Views.PausedPopup
{
    public class PausedPopupPresenter : Presenter<IPausedPopupView>
    {
        private readonly ICommandController _commandController;
        private readonly IGameRunnerService _gameRunnerService;
        private readonly IViewManager _viewManager;

        public PausedPopupPresenter(
            ICommandController commandController,
            IGameRunnerService gameRunnerService,
            IViewManager viewManager,
            IPausedPopupView view) : base(view)
        {
            _commandController = commandController;
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
            _viewManager.OpenView(ViewNames.Confirmation, new ConfirmationMessagePayload(ReturnToLobby));
        }

        private void ReturnToLobby()
        {
            _commandController.Execute<IFinishGameCommand>(new FinishGamePayload(FinishGameReason.ExitRunClick));
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
