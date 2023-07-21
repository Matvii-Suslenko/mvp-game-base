using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Commands.Core;
using Zenject;

namespace ProductMadness.CashmanCasino.Core.Installers
{
    public abstract class MvpInstaller : Installer
    {
        
        private readonly IPresenterBinder _presenterBinder;
        private readonly ICommandBinder _commandBinder;

        protected MvpInstaller(
            IPresenterBinder presenterBinder,
            ICommandBinder commandBinder)
        {
            _presenterBinder = presenterBinder;
            _commandBinder = commandBinder;
        }
        
        public sealed override void InstallBindings()
        {
            BindCommon();
            BindServices();
            BindModels();
            BindPresenters(_presenterBinder);
            BindCommands(_commandBinder);
        }

        protected virtual void BindCommon()
        {
            //override in sub class
        }
        
        protected virtual void BindServices()
        {
            //override in sub class
        }

        protected virtual void BindModels()
        {
            //override in sub class
        }

        protected virtual void BindCommands(ICommandBinder commandBinder)
        {
            //override in sub class
        }
        
        protected virtual void BindPresenters(IPresenterBinder presenterBinder)
        {
            //override in sub class
        }
    }
}