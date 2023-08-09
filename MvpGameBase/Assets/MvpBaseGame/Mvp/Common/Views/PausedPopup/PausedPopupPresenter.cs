using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.Game.Services;

namespace MvpBaseGame.Mvp.Common.Views.PausedPopup
{
    public class PausedPopupPresenter : Presenter<IPausedPopupView>
    {
        private readonly IGameRunnerService _gameRunnerService;

        public PausedPopupPresenter(
            IGameRunnerService gameRunnerService,
            IPausedPopupView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
        }

        public override void Initialize()
        {
            View.CloseClicked += OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            _gameRunnerService.ResumeRun();
            View.SetInteractable(false);
            View.CloseView();
        }

        public override void Dispose()
        {
            View.CloseClicked -= OnCloseClicked;
        }
    }
}
