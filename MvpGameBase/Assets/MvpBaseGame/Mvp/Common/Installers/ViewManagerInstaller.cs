using MvpBaseGame.Assets;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Data.Impl;
using MvpBaseGame.Mvp.ViewManagement.Factories;
using MvpBaseGame.Mvp.ViewManagement.Factories.Impl;
using MvpBaseGame.Mvp.ViewManagement.Focus;
using MvpBaseGame.Mvp.ViewManagement.Focus.Impl;
using MvpBaseGame.Mvp.ViewManagement.History;
using MvpBaseGame.Mvp.ViewManagement.History.Impl;
using MvpBaseGame.Utils.PrefabInstantiator;
using MvpBaseGame.Utils.PrefabInstantiator.Impl;
using ProductMadness.CashmanCasino.Mvp.Views.Overlay;
using UnityEngine;
using Zenject;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class ViewManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private ViewLayerInfo[] _layerInfos;
        
        [SerializeField]
        private BlurOverlayView _blurOverlay;
        
        public override void InstallBindings()
        {
            Container.Bind<IViewLayersFactory>().FromMethod(GetLayerFactory);
            Container.Bind<ICreateViewStrategy>().To<DefaultCreateViewStrategy>().AsSingle();
            Container.Bind<IViewLayerHistoryHandler>().To<ViewLayerHistoryHandler>().AsSingle();
            Container.Bind(typeof(IViewLayerFocusHandler)).To<ViewLayerFocusHandler>().AsSingle();
            Container.Bind<IViewManager>().To<ViewManager>().AsSingle();
            Container.Bind<IViewProvider>().To<ViewProvider>().AsSingle();
            Container.BindInterfacesTo<BlurOverlayManager>().AsSingle().WithArguments(_blurOverlay);

            var viewsContainer = new DiContainer();
            viewsContainer.Bind<IAssetsLoader>().FromMethod(_ => Container.Resolve<IAssetModel>());
            viewsContainer.Bind<IPrefabInstantiator>().To<PrefabInstantiator>().AsSingle();
            
            Container.Bind<IPrefabInstantiator>().FromMethod(() => viewsContainer.Resolve<IPrefabInstantiator>());
        }

        private IViewLayersFactory GetLayerFactory()
        {
            return new ViewLayersFactory(_layerInfos, Container.Resolve<IViewProvider>());
        }
    }
}
