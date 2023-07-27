using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Commands.Core;
using MvpBaseGame.Assets.Impl;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class CoreMvpInstaller : MvpInstaller
    {
        public CoreMvpInstaller(
            IPresenterBinder presenterBinder,
            ICommandBinder commandBinder) : base(presenterBinder, commandBinder)
        {
        }
        
        protected override void BindCommon()
        {
            AddFeatureInstallers();
        }
        
        protected override void BindModels()
        {
            Container.BindInterfacesTo<AssetModel>().AsSingle();
        }

        private void AddFeatureInstallers()
        {
            Container.Install<CommonInstaller>();
        }
    }
}
