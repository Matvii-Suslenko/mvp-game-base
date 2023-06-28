using MvpBaseGame.Commands;
using Zenject;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class BootStrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Install<ApplicationConfigInstaller>();
            // Container.Install<CoreTechInstaller>();
            // Container.Install<PresenterInstaller>();
            Container.Install<CommandInstaller>();
            Container.Install<CoreMvpInstaller>();
            
            Container.BindInterfacesTo<GameRunner>().AsSingle();
        }
    }
}
