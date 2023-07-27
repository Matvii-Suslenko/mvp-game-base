using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.LobbyScreen
{
    public class LobbyScreenView : ScreenBaseView, ILobbyScreenView
    {
        public event Action SettingsClicked;

        [SerializeField]
        protected Button _settingsButton;

        protected override void Awake()
        {
            base.Awake();
            _settingsButton.onClick.AddListener(OnSettingsClicked);
        }

        private void OnSettingsClicked()
        {
            SettingsClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _settingsButton.onClick.RemoveListener(OnSettingsClicked);
        }
    }
}
