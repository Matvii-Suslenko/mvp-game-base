using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Mvp.Common.Commands.Startup.Impl;
using MvpBaseGame.Mvp.Common.Views.PreloaderScreen;
using MvpBaseGame.Mvp.Common.Views.SettingsPopup;
using MvpBaseGame.Mvp.Common.Views.LobbyScreen;
using MvpBaseGame.Mvp.Common.Commands.Startup;
using MvpBaseGame.Mvp.Common.Services;
using MvpBaseGame.Mvp.Common.Helpers;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class CommonInstaller : MvpInstaller
    {
        public CommonInstaller(
            IPresenterBinder presenterBinder,
            ICommandBinder commandBinder) : base(presenterBinder, commandBinder)
        {
        }

        protected override void BindCommon()
        {
            Container.Bind<IUnityLifecycle>().FromInstance(UnityHelper.Instance);
        }

        protected override void BindModels()
        {
            
        }

        protected override void BindServices()
        {
        }
        
        protected override void BindPresenters(IPresenterBinder presenterBinder)
        {
            presenterBinder.BindView<PreloaderScreenView>().ToPresenter<PreloaderScreenPresenter>();
            presenterBinder.BindView<LobbyScreenView>().ToPresenter<LobbyScreenPresenter>();
            presenterBinder.BindView<SettingsPopupView>().ToPresenter<SettingsPopupPresenter>();
            presenterBinder.BindView<PausedPopupView>().ToPresenter<PausedPopupPresenter>();
        }

        protected override void BindCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<IStartupCommand>().ToCommand<StartupCommand>();
        }
    }
}
