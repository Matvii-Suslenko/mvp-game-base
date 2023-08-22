using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Commands.Core;

namespace MvpBaseGame.Mvp.Game.Payloads
{
    public interface IFinishGamePayload : ICommandPayload
    {
        FinishGameReason FinishGameReason { get; }
    }
}
