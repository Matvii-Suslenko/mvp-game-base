using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Models;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameRunnerService : IGameRunnerService
    {
        private const float ForwardSpeed = 15f;
        
        private bool _isRunning;
            
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

        public void Dispose()
        {
            _unityLifecycle.Updated -= OnUpdated;
        }
    }
}
