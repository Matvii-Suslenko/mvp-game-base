using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage
{
    public class ConfirmationMessageView : PopupBaseView, IConfirmationMessageView
    {
        public event Action ConfirmClicked;
        
        [SerializeField]
        protected Button _confirmButton;

        protected override void Awake()
        {
            base.Awake();
            _confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
            _confirmButton.interactable = isInteractable;
        }

        private void OnConfirmButtonClicked()
        {
            ConfirmClicked?.Invoke();
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            _confirmButton.onClick.RemoveListener(OnConfirmButtonClicked);;
        }
    }
}
