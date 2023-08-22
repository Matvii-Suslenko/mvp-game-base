using MvpBaseGame.Mvp.ViewManagement.Core.Impl;
using MvpBaseGame.Mvp.ViewManagement.Core;
using MvpBaseGame.Commands.Core.Impl;
using MvpBaseGame.Mvp.Game.Payloads;
using MvpBaseGame.Mvp.Game.Services;

namespace MvpBaseGame.Mvp.Game.Commands.Impl
{
    public class FinishGameCommand : Command<IFinishGamePayload>, IFinishGameCommand
    {
        private readonly IGameRunnerService _gameRunnerService;
        private readonly IViewManager _viewManager;

        public FinishGameCommand(
            IGameRunnerService gameRunnerService,
            IViewManager viewManager)
        {
            _gameRunnerService = gameRunnerService;
            _viewManager = viewManager;
        }
        
        protected override void Execute(IFinishGamePayload value)
        {
            _gameRunnerService.StopRun();
            _viewManager.OpenView(ViewNames.Lobby);
            _gameRunnerService.ResetPencilPosition();
        }
    }
}
