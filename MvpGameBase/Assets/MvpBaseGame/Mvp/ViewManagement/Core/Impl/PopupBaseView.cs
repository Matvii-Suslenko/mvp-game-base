using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class PopupBaseView : ScreenBaseView, IPopupBaseView
    {
        public event Action CloseClicked;

        private bool IsCloseButtonEnabled
        {
            get
            {
                if (CloseButton == null)
                {
                    return false;
                }

                return _closeByBackButton && CloseButton.IsActive() && CloseButton.interactable;
            }
        }

        [SerializeField]
        protected bool _closeByBackButton = true;

        [SerializeField]
        protected Button CloseButton;

        protected override void Awake()
        {
            base.Awake();

            if (CloseButton == null)
            {
                return;
            }

            CloseButton.onClick.AddListener(OnCloseClick);
            DeviceBackClicked += OnDeviceBackClicked;
        }
        
        private void OnDeviceBackClicked()
        {
            if (IsCloseButtonEnabled)
            {
                CloseButton.onClick.Invoke();
            }
        }

        protected void OnCloseClick()
        {
            CloseClicked?.Invoke();      
        }

        protected override void OnInteractableChanged(bool interactable)
        {
            if (CloseButton != null)
            {
                CloseButton.interactable = interactable;
            }
        }

        protected override void OnDestroy()
        {
            DeviceBackClicked -= OnDeviceBackClicked;

            if (CloseButton != null)
            {
                CloseButton.onClick.RemoveListener(OnCloseClick);
            }

            base.OnDestroy();
        }
    }
}