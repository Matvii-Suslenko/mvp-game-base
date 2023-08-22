using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Game.Views.FailedGamePopup
{
    public class FailedGamePopupView : ScreenBaseView, IFailedGamePopupView
    {
        public event Action FinishGameClicked;
        public event Action WatchAdClicked;
        
        [SerializeField]
        protected Button _finishGameButton;
        
        [SerializeField]
        protected Button _watchAddButton;
        
        protected override void Awake()
        {
            base.Awake();
            _finishGameButton.onClick.AddListener(OnFinishGameButtonClicked);
            _watchAddButton.onClick.AddListener(OnWatchAddButtonClicked);
        }

        protected override void OnInteractableChanged(bool isInteractable)
        {
            base.OnInteractableChanged(isInteractable);
            _finishGameButton.interactable = isInteractable;
            _watchAddButton.interactable = isInteractable;
        }

        private void OnFinishGameButtonClicked()
        {
            FinishGameClicked?.Invoke();
        }
        
        private void OnWatchAddButtonClicked()
        {
            WatchAdClicked?.Invoke();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _finishGameButton.onClick.RemoveListener(OnFinishGameButtonClicked);
            _watchAddButton.onClick.RemoveListener(OnWatchAddButtonClicked);
        }
    }
}
