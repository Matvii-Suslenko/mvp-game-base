using MvpBaseGame.Mvp.Common.Components.DragZone.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.Serialization;

namespace MvpBaseGame.Mvp.Game.Views.GameScreen
{
    public class GameScreenView : ScreenBaseView, IGameScreenView
    {
        public event Action<float> Drag;
        
        public event Action SoundButtonClicked;
        public event Action PauseButtonClicked;
        
        [SerializeField]
        protected Button _soundButton;
        
        [SerializeField]
        protected Button _pauseButton;

        [FormerlySerializedAs("_dragZone")] [SerializeField]
        protected OneDimensionalJoystickArea joystickArea;

        protected override void Awake()
        {
            base.Awake();
            _soundButton.onClick.AddListener(OnSoundButtonClicked);
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
            joystickArea.Drag += OnDrag;
        }

        private void OnDrag(float dragValue)
        {
            Drag?.Invoke(dragValue);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            _soundButton.interactable = isInteractable;
            _pauseButton.interactable = isInteractable;
        }

        private void OnPauseButtonClicked()
        {
            PauseButtonClicked?.Invoke();
        }

        private void OnSoundButtonClicked()
        {
            SoundButtonClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _soundButton.onClick.RemoveListener(OnSoundButtonClicked);
            _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            joystickArea.Drag -= OnDrag;
        }
    }
}
