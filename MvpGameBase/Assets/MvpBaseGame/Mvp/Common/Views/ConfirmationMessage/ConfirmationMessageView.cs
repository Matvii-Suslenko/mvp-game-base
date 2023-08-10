using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Views.ConfirmationMessage
{
    public class ConfirmationMessageView : ScreenBaseView, IConfirmationMessageView
    {
        public event Action ConfirmClicked;
        public event Action CancelClicked;
        
        [SerializeField]
        protected Button _confirmButton;
        
        [SerializeField]
        protected Button _cancelButton;

        protected override void Awake()
        {
            base.Awake();
            _confirmButton.onClick.AddListener(OnConfirmButtonClicked);
            _cancelButton.onClick.AddListener(OnCancelButtonClicked);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
            _confirmButton.interactable = isInteractable;
            _cancelButton.interactable = isInteractable;
        }

        private void OnConfirmButtonClicked()
        {
            ConfirmClicked?.Invoke();
        }
        
        private void OnCancelButtonClicked()
        {
            CancelClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _confirmButton.onClick.RemoveListener(OnConfirmButtonClicked);
            _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
        }
    }
}
