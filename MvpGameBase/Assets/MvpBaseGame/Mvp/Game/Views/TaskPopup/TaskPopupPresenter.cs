using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Services;
using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupPresenter : Presenter<ITaskPopupView>
    {
        private IGameTask _gameTask;
        
        private readonly IGameTaskService _gameTaskService;
        private readonly IUnityLifecycle _unityLifecycle;

        public TaskPopupPresenter(
            IGameTaskService gameTaskService,
            IUnityLifecycle unityLifecycle,
            ITaskPopupView view) : base(view)
        {
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
