using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Services;
using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupPresenter : Presenter<ITaskPopupView>
    {
        private IGameTask _gameTask;

        private readonly IGameRunnerService _gameRunnerService;
        private readonly IGameTaskService _gameTaskService;
        private readonly IUnityLifecycle _unityLifecycle;

        public TaskPopupPresenter(
            IGameRunnerService gameRunnerService,
            IGameTaskService gameTaskService,
            IUnityLifecycle unityLifecycle,
            ITaskPopupView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
            _gameTaskService = gameTaskService;
            _unityLifecycle = unityLifecycle;
        }

        public override void Initialize()
        {
            _unityLifecycle.Paused += OnPaused;
            _gameTask = _gameTaskService.GetNewTask();
            
            View.SetGameTask(_gameTask);
            View.OptionClicked += OnOptionClicked;
        }

        private void OnOptionClicked(int optionIndex)
        {
            View.SetInteractable(false);

            if (optionIndex == _gameTask.Answer)
            {
                _gameRunnerService.HealPencil();
            }
            
            _gameRunnerService.ResumeRun();
            View.CloseView();
        }

        private void OnPaused(bool isPaused)
        {
            // TODO: stop countdown on pause and resume on come back
        }

        public override void Dispose()
        {
            _unityLifecycle.Paused -= OnPaused;
            View.OptionClicked -= OnOptionClicked;
        }
    }
}
