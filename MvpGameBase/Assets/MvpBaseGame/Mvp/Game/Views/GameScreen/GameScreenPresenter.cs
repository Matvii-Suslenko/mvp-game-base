using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Services;

namespace MvpBaseGame.Mvp.Game.Views.GameScreen
{
    public class GameScreenPresenter : Presenter<IGameScreenView>
    {
        private readonly IGameRunnerService _gameRunnerService;
        private readonly IViewManager _viewManager;

        public GameScreenPresenter(
            IGameRunnerService gameRunnerService,
            IViewManager viewManager,
            IGameScreenView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
            _viewManager = viewManager;
        }

        public override void Initialize()
        {
            View.DeviceBackClicked += OnDeviceBack;
            _gameRunnerService.StartRun();
        }
        
        private void OnDeviceBack()
        {
            _viewManager.OpenView(ViewNames.Paused);
        }

        public override void Dispose()
        {
            View.DeviceBackClicked -= OnDeviceBack;
        }
    }
}
