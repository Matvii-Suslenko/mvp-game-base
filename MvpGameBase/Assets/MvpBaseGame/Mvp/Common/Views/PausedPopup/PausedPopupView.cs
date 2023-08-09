using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.PausedPopup
{
    public class PausedPopupView : PopupBaseView, IPausedPopupView
    {
        public event Action BackToLobbyClicked;
        
        [SerializeField]
        protected Button _backToLobbyButton;

        protected override void Awake()
        {
            base.Awake();
            _backToLobbyButton.onClick.AddListener(OnBackToLobbyButtonClicked);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
            _backToLobbyButton.interactable = isInteractable;
        }

        private void OnBackToLobbyButtonClicked()
        {
            BackToLobbyClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _backToLobbyButton.onClick.RemoveListener(OnBackToLobbyButtonClicked);
        }
    }
}
