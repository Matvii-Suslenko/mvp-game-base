using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Payloads.Impl;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Mvp.Game.Models;
using MvpBaseGame.Mvp.Game.Data;
using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameRunnerService : IGameRunnerService
    {
        private IPencilObject Pencil => _runnerObjectsModel.Pencil;
        
        private const float MinimumPencilRotation = -30f;
        private const float MaximumPencilRotation = 30f;
        private const float PencilRotationFading = 45f;
        
        private const float HorizontalSpeedMultiplier = 25f;
        private const float RotationMultiplier = 70;
        private const float ForwardSpeed = 30f;
        
        private const float HealthLoosingSpeed = 0.06f;

        private float _horizontalMovement;
        private float _health = 1;
        private bool _isRunning;
        private bool _isPaused;

        private readonly Vector3 _startPencilPosition = new (12, 0, -22.95f);
        private readonly IRunnerObjectsModel _runnerObjectsModel;
        private readonly IUnityLifecycle _unityLifecycle;
        private readonly IViewManager _viewManager;

        public GameRunnerService(
            IRunnerObjectsModel runnerObjectsModel,
            IUnityLifecycle unityLifecycle,
            IViewManager viewManager)
        {
            _runnerObjectsModel = runnerObjectsModel;
            _unityLifecycle = unityLifecycle;
            _viewManager = viewManager;
        }

        private void OnUpdated(float deltaTime)
        {
            Pencil.Move(new Vector3(_horizontalMovement * HorizontalSpeedMultiplier * deltaTime, 0, ForwardSpeed * deltaTime));
            Pencil.Rotate(_horizontalMovement * RotationMultiplier * deltaTime);
            Pencil.SetLength(_health);
            
            _horizontalMovement = 0;
            
            _health = Mathf.Clamp(_health - HealthLoosingSpeed * deltaTime, 0f, 1f);

            if (Mathf.Approximately(_health, 0))
            {
                PauseRun();
                _viewManager.OpenView(ViewNames.Failed, new FinishGamePayload(FinishGameReason.NoHealth));
            }
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
            
            _health = 1; // TODO: add recovering animation
            Pencil.Rotate(0);
            Pencil.SetLength(1);
        }

        public void MovePencil(float horizontalMovement)
        {
            _horizontalMovement = horizontalMovement;
        }

        public void ResetPencilPosition()
        {
            Pencil.SetPosition(_startPencilPosition);
        }

        public void Dispose()
        {
            _unityLifecycle.Updated -= OnUpdated;
        }
    }
}
