using MvpBaseGame.Mvp.Common.Views.ConfirmationMessage.Payload;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Utils.CoroutineRunner.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.Game.Payloads.Impl;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Game.Components;
using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Mvp.Game.Models;
using System.Collections.Generic;
using MvpBaseGame.Mvp.Game.Data;
using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameRunnerService : IGameRunnerService
    {
        private IPencilObject Pencil => _runnerObjectsModel.Pencil;
        
        private const float Gravity = -9.81f;
        
        private const float MinimumPencilRotation = -30f;
        private const float MaximumPencilRotation = 30f;
        private const float PencilRotationFading = 45f;
        
        private const float HorizontalSpeedMultiplier = 25f;
        private const float RotationMultiplier = 70;
        private const float ForwardSpeed = 30f;
        
        private const float HealthLoosingSpeed = 0.05f;

        private IList<ITaskSticker> _seenTasks = new List<ITaskSticker>();
        private float _horizontalMovement;
        private float _health = 1;
        private bool _isRunning;
        private bool _isPaused;

        private readonly Vector3 _startPencilPosition = new (12, 0, -22.95f);
        private readonly IRunnerObjectsModel _runnerObjectsModel;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IUnityLifecycle _unityLifecycle;
        private readonly IViewManager _viewManager;

        public GameRunnerService(
            IRunnerObjectsModel runnerObjectsModel,
            ICoroutineRunner coroutineRunner,
            IUnityLifecycle unityLifecycle,
            IViewManager viewManager)
        {
            _runnerObjectsModel = runnerObjectsModel;
            _coroutineRunner = coroutineRunner;
            _unityLifecycle = unityLifecycle;
            _viewManager = viewManager;
        }

        private void OnUpdated(float deltaTime)
        {
            Pencil.Move(new Vector3(_horizontalMovement * HorizontalSpeedMultiplier, Gravity, ForwardSpeed) * deltaTime);
            Pencil.Rotate(_horizontalMovement * RotationMultiplier * deltaTime);
            Pencil.SetLength(_health);
            
            _horizontalMovement = 0;

            if (!Pencil.IsGrounded)
            {
                return;
            }
            
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
            Subscribe();
        }
        
        public void PauseRun()
        {
            if (!_isRunning || _isPaused)
            {
                return;
            }

            _isPaused = true;
            Unsubscribe();
        }
        
        public void ResumeRun()
        {
            if (!_isRunning || !_isPaused)
            {
                _isPaused = false;
                return;
            }

            _isPaused = false;
            Subscribe();
        }
        
        public void StopRun()
        {
            if (!_isRunning)
            {
                return;
            }

            _isPaused = false;
            _isRunning = false;
            _seenTasks.Clear();
            Unsubscribe();
            
            Pencil.Rotate(0);
            HealPencil();
        }

        public void MovePencil(float horizontalMovement)
        {
            _horizontalMovement = horizontalMovement;
        }

        public void ResetPencilPosition()
        {
            Pencil.SetPosition(_startPencilPosition);
        }

        private void Subscribe()
        {
            _unityLifecycle.Updated += OnUpdated;
            Pencil.TaskFound += OnTaskFound;
        }

        private void Unsubscribe()
        {
            _unityLifecycle.Updated -= OnUpdated;
            Pencil.TaskFound -= OnTaskFound;
        }
        
        private void OnTaskFound(ITaskSticker taskSticker)
        {
            if (_seenTasks.Contains(taskSticker))
            {
                return;
            }
            
            PauseRun();
            _seenTasks.Add(taskSticker);
            _viewManager.OpenView(ViewNames.Task, new ConfirmationMessagePayload(OnRightAnswered, OnWrongAnswered));
        }

        private void OnRightAnswered()
        {
            // TODO: fix tap
            
            HealPencil();
            _coroutineRunner.AfterSeconds(0.5f, ResumeRun);
        }

        private void OnWrongAnswered()
        {
            // TODO: fix tap
            
            _coroutineRunner.AfterSeconds(0.5f, ResumeRun);
        }

        private void HealPencil()
        {
            _health = 1; // TODO: add recovering animation
            Pencil.SetLength(1);
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
