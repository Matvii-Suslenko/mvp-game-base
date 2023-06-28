using MvpBaseGame.Commands.Core;
using Zenject;

namespace ProductMadness.CashmanCasino.Core.Installers
{
    public abstract class MvpInstaller : Installer
    {
        
        //private readonly IPresenterBinder _presenterBinder; // TODO: uncomment after Presenter Binder Implemented
        private readonly ICommandBinder _commandBinder;

        protected MvpInstaller(
            //IPresenterBinder presenterBinder, // TODO: uncomment after Presenter Binder Implemented
            ICommandBinder commandBinder)
        {
            //_presenterBinder = presenterBinder; // TODO: uncomment after Presenter Binder Implemented
            _commandBinder = commandBinder;
        }
        
        public sealed override void InstallBindings()
        {
            BindCommon();
            BindServices();
            BindModels();
            //indPresenters(_presenterBinder);
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

        // TODO: uncomment after Presenter Binder Implemented
        // protected virtual void BindPresenters(IPresenterBinder presenterBinder)
        // {
        //     //override in sub class
        // }
    }
}