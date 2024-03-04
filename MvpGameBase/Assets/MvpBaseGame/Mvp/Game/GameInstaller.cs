using MvpBaseGame.Mvp.ViewManagement.Presenters.Main;
using MvpBaseGame.Mvp.Game.Views.FailedGamePopup;
using MvpBaseGame.Mvp.Game.Views.GameScreen;
using MvpBaseGame.Mvp.Game.Views.TaskPopup;
using MvpBaseGame.Mvp.Game.Services.Impl;
using MvpBaseGame.Mvp.Game.Commands.Impl;
using MvpBaseGame.Mvp.Common.Installers;
using MvpBaseGame.Mvp.Game.Models.Impl;
using MvpBaseGame.Mvp.Game.Commands;
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
            Container.BindInterfacesTo<GameTaskService>().AsSingle();
        }
        
        protected override void BindPresenters(IPresenterBinder presenterBinder)
        {
            presenterBinder.BindView<GameScreenView>().ToPresenter<GameScreenPresenter>();
            presenterBinder.BindView<TaskPopupView>().ToPresenter<TaskPopupPresenter>();
            presenterBinder.BindView<FailedGamePopupView>().ToPresenter<FailedGamePopupPresenter>();
        }

        protected override void BindCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<IFinishGameCommand>().ToCommand<FinishGameCommand>();
        }
    }
}
