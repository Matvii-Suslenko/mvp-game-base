namespace MvpBaseGame.Mvp.Game.Data
{
    public interface IGameTask
    {
        /// <summary>
        /// Game Task Question
        /// </summary>
        string Question { get; }
        
        /// <summary>
        /// Game Task Answer Options
        /// </summary>
        string[] Options { get; }
        
        /// <summary>
        /// Index of The Right Answer
        /// </summary>
        int Answer { get; }
    }
}
