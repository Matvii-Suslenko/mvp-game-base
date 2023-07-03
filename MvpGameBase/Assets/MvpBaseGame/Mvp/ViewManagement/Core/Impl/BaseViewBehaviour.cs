using MvpBaseGame.Assets;
using Plugins.Zenject.Source.Providers.PrefabCreators;
using UnityEngine;
using Zenject;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class BaseViewBehaviour : MonoBehaviour
    {
        protected IAssetsLoader AssetModel {get; private set;}
        protected IPrefabInstantiator PrefabInstantiator { get; private set; }

        [Inject]
        private void Initialise(
            IAssetsLoader assetModel,
            IPrefabInstantiator instantiator
            )
        {
            AssetModel = assetModel;
            PrefabInstantiator = instantiator;
        }
        
        protected virtual void OnDestroy()
        {
        }
    }
}
