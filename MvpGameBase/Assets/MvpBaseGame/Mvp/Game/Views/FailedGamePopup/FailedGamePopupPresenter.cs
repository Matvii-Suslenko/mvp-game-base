using MvpBaseGame.Mvp.ViewManagement.Presenters.Main.Impl;
using MvpBaseGame.Mvp.Game.Payloads.Impl;
using MvpBaseGame.Mvp.Game.Commands;
using MvpBaseGame.Mvp.Game.Payloads;
using MvpBaseGame.Commands.Core;
using System;

namespace MvpBaseGame.Mvp.Game.Views.FailedGamePopup
{
    public class FailedGamePopupPresenter : Presenter<IFailedGamePopupView>
    {
        private readonly ICommandController _commandController;
        private readonly IFinishGamePayload _payload;

        public FailedGamePopupPresenter(
            ICommandController commandController,
            IFailedGamePopupView view,
            IFinishGamePayload payload) : base(view)
        {
            _commandController = commandController;
            _payload = payload;
        }

        public override void Initialize()
        {
            View.FinishGameClicked += OnFinishGameClicked;
            View.WatchAdClicked += OnWatchAdClicked;
        }

        private void OnWatchAdClicked()
        {
            // TODO: implement
            throw new NotImplementedException(); // TODO: delete System using
        }

        private void OnFinishGameClicked()
        {
            _commandController.Execute<IFinishGameCommand>(new FinishGamePayload(_payload.FinishGameReason));
        }

        public override void Dispose()
        {
            View.FinishGameClicked -= OnFinishGameClicked;
            View.WatchAdClicked -= OnWatchAdClicked;
        }
    }
}
