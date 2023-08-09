using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Models;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameRunnerService : IGameRunnerService
    {
        private const float ForwardSpeed = 15f;
        
        private bool _isRunning;
        private bool _isPaused;
            
        private readonly IRunnerObjectsModel _runnerObjectsModel;
        private readonly IUnityLifecycle _unityLifecycle;

        public GameRunnerService(
            IRunnerObjectsModel runnerObjectsModel,
            IUnityLifecycle unityLifecycle)
        {
            _runnerObjectsModel = runnerObjectsModel;
            _unityLifecycle = unityLifecycle;
        }
        
        private void OnUpdated(float deltaTime)
        {
            _runnerObjectsModel.Pencil.MoveForward(deltaTime * ForwardSpeed);
        }

        public void StartRun()
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;
            _unityLifecycle.Updated += OnUpdated;
        }
        
        public void PauseRun()
        {
            if (!_isRunning || _isPaused)
            {
                return;
            }

            _isPaused = true;
            _unityLifecycle.Updated -= OnUpdated;
        }
        
        public void ResumeRun()
        {
            if (!_isRunning || !_isPaused)
            {
                _isPaused = false;
                return;
            }

            _isPaused = false;
            _unityLifecycle.Updated += OnUpdated;
        }
        
        public void StopRun()
        {
            if (!_isRunning)
            {
                return;
            }

            _isRunning = false;
            _unityLifecycle.Updated -= OnUpdated;
        }

        public void Dispose()
        {
            _unityLifecycle.Updated -= OnUpdated;
        }
    }
}
