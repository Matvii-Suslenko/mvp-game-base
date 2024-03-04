using MvpBaseGame.Mvp.Game.Data.Impl;
using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Services.Impl
{
    public class GameTaskService : IGameTaskService
    {
        public IGameTask GetNewTask()
        {
            return new GameTask("17+20=?", new []{ "17", "-37", "37", "27" }, 2);
        }
    }
}
