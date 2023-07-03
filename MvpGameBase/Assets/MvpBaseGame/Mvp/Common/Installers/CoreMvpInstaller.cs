using MvpBaseGame.Assets.Impl;
using ProductMadness.CashmanCasino.Core.Installers;
using MvpBaseGame.Commands.Core;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Utils.CoroutineRunner.Impl;
using UnityEngine;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class CoreMvpInstaller : MvpInstaller
    {
        public CoreMvpInstaller(ICommandBinder commandBinder) : base(commandBinder)
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
