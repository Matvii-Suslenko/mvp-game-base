using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public class LobbyScreenView : ScreenBaseView, ILobbyScreenView
    {
        public event Action SoundButtonClicked;
        public event Action PlayButtonClicked;

        [SerializeField]
        protected Button _soundButton;
        
        [SerializeField]
        protected Button _playButton;
        
        [SerializeField]
        protected GameObject _lobbySign;

        protected override void Awake()
        {
            base.Awake();
            _soundButton.onClick.AddListener(OnSoundButtonClicked);
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }

        private void OnSoundButtonClicked()
        {
            SoundButtonClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _soundButton.onClick.RemoveListener(OnSoundButtonClicked);
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }
    }
}
