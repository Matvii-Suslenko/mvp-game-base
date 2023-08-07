using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public class LobbyScreenView : ScreenBaseView, ILobbyScreenView
    {
        public event Action SoundButtonClicked;

        [SerializeField]
        protected Button _soundButton;

        protected override void Awake()
        {
            base.Awake();
            _soundButton.onClick.AddListener(OnSoundButtonClicked);
        }

        private void OnSoundButtonClicked()
        {
            SoundButtonClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _soundButton.onClick.RemoveListener(OnSoundButtonClicked);
        }
    }
}
