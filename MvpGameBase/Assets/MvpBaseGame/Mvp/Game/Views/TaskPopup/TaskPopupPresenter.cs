using MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Services;
using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupPresenter : Presenter<ITaskPopupView>
    {
        private IGameTask _gameTask;

        private readonly IConfirmationMessagePayload _payload;
        private readonly IGameRunnerService _gameRunnerService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IGameTaskService _gameTaskService;
        private readonly IUnityLifecycle _unityLifecycle;

        public TaskPopupPresenter(
            IConfirmationMessagePayload payload,
            IGameRunnerService gameRunnerService,
            ICoroutineRunner coroutineRunner,
            IGameTaskService gameTaskService,
            IUnityLifecycle unityLifecycle,
            ITaskPopupView view) : base(view)
        {
            _gameRunnerService = gameRunnerService;
            _coroutineRunner = coroutineRunner;
            _gameTaskService = gameTaskService;
            _unityLifecycle = unityLifecycle;
            _payload = payload;
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
                _payload.OnConfirm?.Invoke();
            }
            else
            {
                _payload.OnCancel?.Invoke();
            }
            
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
