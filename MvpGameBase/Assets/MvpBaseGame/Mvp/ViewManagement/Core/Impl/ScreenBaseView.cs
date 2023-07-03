using MvpBaseGame.Utils.PrefabInstantiator;
using MvpBaseGame.Assets;
using UnityEngine;
using Zenject;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class ScreenBaseView : ManagedView, IScreenBaseView
    {
        public event Action DeviceBackClicked;
        public event Action<bool> FocusChanged;
        protected IAssetsLoader AssetModel {get; private set;}
        protected IPrefabInstantiator PrefabInstantiator {get; private set;}

        [Inject]
        private void Initialise(
            IAssetsLoader assetModel,
            IPrefabInstantiator instantiator
        )
        {
            AssetModel = assetModel;
            PrefabInstantiator = instantiator;
        }
        
        private void Update()
        {
            if (HasFocus && Transition.IsPlayInComplete && IsInteractable && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                DeviceBackClicked?.Invoke();
            }
        }

        protected override void OnFocusChanged(bool hasFocus)
        {
            FocusChanged?.Invoke(hasFocus);
        }
    }
}