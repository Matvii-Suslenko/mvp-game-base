using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Mvp.Game.Views.GameScreen;
using MvpBaseGame.Mvp.Game.Services.Impl;
using MvpBaseGame.Mvp.Common.Installers;
using MvpBaseGame.Mvp.Game.Models.Impl;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Game
{
    public class GameInstaller : MvpInstaller
    {
        public GameInstaller(
            IPresenterBinder presenterBinder,
            ICommandBinder commandBinder) : base(presenterBinder, commandBinder)
        {
        }

        protected override void BindCommon()
        {
            
        }

        protected override void BindModels()
        {
            Container.BindInterfacesTo<RunnerObjectsModel>().AsSingle();
        }

        protected override void BindServices()
        {
            Container.BindInterfacesTo<GameRunnerService>().AsSingle();
        }
        
        protected override void BindPresenters(IPresenterBinder presenterBinder)
        {
            presenterBinder.BindView<GameScreenView>().ToPresenter<GameScreenPresenter>();
        }

        protected override void BindCommands(ICommandBinder commandBinder)
        {
            
        }
    }
}
