using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Services;

namespace MvpBaseGame.Mvp.Game.Views.GameScreen
{
    public class GameScreenPresenter : Presenter<IGameScreenView>
    {
        private readonly IGameRunnerService _gameRunnerService;
        private readonly IUnityLifecycle _unityLifecycle;
        private readonly IViewManager _viewManager;

        public GameScreenPresenter(
            IGameRunnerService gameRunnerService,
            IUnityLifecycle unityLifecycle,
            IViewManager viewManager,
            IGameScreenView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
            _unityLifecycle = unityLifecycle;
            _viewManager = viewManager;
        }

        public override void Initialize()
        {
            View.PauseButtonClicked += PauseGameRun;
            View.DeviceBackClicked += PauseGameRun;
            _unityLifecycle.Paused += OnPaused;
            View.Drag += OnDrag;
            
            _gameRunnerService.StartRun();
        }

        private void OnDrag(float input)
        {
            _gameRunnerService.MovePencil(input);
        }

        private void OnPaused(bool isPaused)
        {
            if (isPaused && View.HasFocus)
            {
                PauseGameRun();
            }
        }

        private void PauseGameRun()
        {
            _gameRunnerService.PauseRun();
            _viewManager.OpenView(ViewNames.Paused);
        }

        public override void Dispose()
        {
            View.PauseButtonClicked -= PauseGameRun;
            View.DeviceBackClicked -= PauseGameRun;
            _unityLifecycle.Paused -= OnPaused;
            View.Drag -= OnDrag;
        }
    }
}
