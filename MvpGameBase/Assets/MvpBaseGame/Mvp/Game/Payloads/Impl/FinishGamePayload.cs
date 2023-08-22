using MvpBaseGame.Mvp.Game.Data.Impl;

namespace MvpBaseGame.Mvp.Game.Payloads.Impl
{
    public class FinishGamePayload : IFinishGamePayload
    {
        public FinishGameReason FinishGameReason { get; }

        public FinishGamePayload(FinishGameReason finishGameReason)
        {
            FinishGameReason = finishGameReason;
        }
    }
}