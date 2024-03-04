using MvpBaseGame.Mvp.Game.Data;

namespace MvpBaseGame.Mvp.Game.Services
{
    public interface IGameTaskService
    {
        /// <summary>
        /// Creates New Game Task
        /// </summary>
        /// <returns>New Game Task</returns>
        IGameTask GetNewTask();
    }
}
