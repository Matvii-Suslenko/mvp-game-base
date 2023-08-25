namespace MvpBaseGame.Mvp.Game.Components
{
    public interface ITaskSticker
    {
        /// <summary>
        /// True if Task is Already Seen
        /// </summary>
        bool IsSeen { get; }

        /// <summary>
        /// Sets Is Seen to True
        /// </summary>
        void SetIsSeen();
    }
}
