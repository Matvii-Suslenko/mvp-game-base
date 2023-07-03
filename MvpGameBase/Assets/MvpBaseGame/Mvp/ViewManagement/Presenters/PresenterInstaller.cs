using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using Zenject;

namespace MvpBaseGame.Mvp.ViewManagement.Presenters
{
    public class PresenterInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IPresenterBinder>().To<PresenterBinder>().AsSingle();
            Container.Bind<IPresenterCreator>().To<PresenterCreator>().AsSingle();
            Container.Bind<IPresenterFactory>().To<PresenterFactory>().AsSingle().
                WhenInjectedInto<IPresenterBinder>();
        }
    }
}