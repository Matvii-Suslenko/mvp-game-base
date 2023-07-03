using MvpBaseGame.Mvp.Common.Commands.Startup.Impl;
using ProductMadness.CashmanCasino.Core.Installers;
using MvpBaseGame.Mvp.Common.Commands.Startup;
using MvpBaseGame.Commands.Core;
using MvpBaseGame.Mvp.Common.Views.PreloaderScreen;
using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;

namespace MvpBaseGame.Mvp.Common.Installers
{
    public class CommonInstaller : MvpInstaller
    {
        public CommonInstaller(
            //IPresenterBinder presenterBinder,  // TODO: uncomment after Presenter Binder Implemented
            ICommandBinder commandBinder) : base(/*presenterBinder,*/ commandBinder)
        {
        }

        protected override void BindCommon()
        {
            
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
        }

        protected override void BindCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<IStartupCommand>().ToCommand<StartupCommand>();
        }
    }
}
