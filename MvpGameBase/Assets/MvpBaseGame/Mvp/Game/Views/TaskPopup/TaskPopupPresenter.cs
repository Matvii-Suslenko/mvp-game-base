using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.Common.Services;

namespace MvpBaseGame.Mvp.Game.Views.TaskPopup
{
    public class TaskPopupPresenter : Presenter<ITaskPopupView>
    {
        private readonly IUnityLifecycle _unityLifecycle;

        public TaskPopupPresenter(
            IUnityLifecycle unityLifecycle,
            ITaskPopupView view) : base(view)
        {
            _unityLifecycle = unityLifecycle;
        }

        public override void Initialize()
        {
            _unityLifecycle.Paused += OnPaused;
        }

        private void OnPaused(bool isPaused)
        {
            // TODO: stop countdown on pause and resume on come back
        }

        public override void Dispose()
        {
            _unityLifecycle.Paused += OnPaused;
        }
    }
}
