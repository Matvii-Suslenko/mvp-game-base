using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Data;
using MvpBaseGame.Mvp.Game.Models;
using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameRunnerService : IGameRunnerService
    {
        private IPencilObject Pencil => _runnerObjectsModel.Pencil;
        
        private const float PencilRotationFading = 0.05f;
        private const float MinimumPencilRotation = -30f;
        private const float MaximumPencilRotation = 30f;
        
        private const float HorizontalSpeedMultiplier = 0.05f;
        private const float RotationMultiplier = 0.15f;
        private const float ForwardSpeed = 0.05f;

        private float _horizontalMovement;
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
        
        // todo: base on health:
        private float _health = 1;
        
        private void OnUpdated(float deltaTime)
        {
            Pencil.Move(new Vector3(_horizontalMovement * HorizontalSpeedMultiplier, 0, ForwardSpeed));
            Pencil.Rotate(_horizontalMovement * RotationMultiplier);
            _horizontalMovement = 0;
            
            // todo: base on health
            Pencil.SetLength(_health);
            _health = Mathf.Clamp(_health - 0.1f * deltaTime, 0f, 1f);
        }

        public void StartRun()
        {
            if (_isRunning)
            {
                return;
            }

            _runnerObjectsModel.Pencil.RotationFading = PencilRotationFading;
            _runnerObjectsModel.Pencil.MinimumRotation = MinimumPencilRotation;
            _runnerObjectsModel.Pencil.MaximumRotation = MaximumPencilRotation;

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

            _isPaused = false;
            _isRunning = false;
            _unityLifecycle.Updated -= OnUpdated;
        }

        public void MovePencil(float horizontalMovement)
        {
            _horizontalMovement = horizontalMovement;
        }

        public void Dispose()
        {
            _unityLifecycle.Updated -= OnUpdated;
        }
    }
}
