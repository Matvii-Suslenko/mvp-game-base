using MvpBaseGame.Mvp.ViewManagement.Presenters;
using MvpBaseGame.Utils.CoroutineRunner.Impl;
using MvpBaseGame.Utils.CoroutineRunner;
using MvpBaseGame.Commands;
using Zenject;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class BootStrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(new CoroutineRunner(this));
            Container.Install<PresenterInstaller>();
            Container.Install<CommandInstaller>();
            Container.Install<CoreMvpInstaller>();
            
            Container.BindInterfacesTo<GameRunner>().AsSingle();
        }
    }
}
