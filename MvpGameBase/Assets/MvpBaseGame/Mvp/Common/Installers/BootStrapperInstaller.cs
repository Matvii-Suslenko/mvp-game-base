using MvpBaseGame.Mvp.ViewManagement.Presenters;
using MvpBaseGame.Commands;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Utils.CoroutineRunner.Impl;
using UnityEngine;
using Zenject;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class BootStrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(new CoroutineRunner(this));
            // Container.Install<ApplicationConfigInstaller>();
            // Container.Install<CoreTechInstaller>();
            Container.Install<PresenterInstaller>();
            Container.Install<CommandInstaller>();
            Container.Install<CoreMvpInstaller>();
            
            Container.BindInterfacesTo<GameRunner>().AsSingle();
        }
    }
}
