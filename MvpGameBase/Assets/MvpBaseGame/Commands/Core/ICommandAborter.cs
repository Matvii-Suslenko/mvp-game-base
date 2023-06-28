namespace MvpBaseGame.Commands.Core
{
    public interface ICommandAborter
    {
        /// <summary>
        /// Interrupts Running Commands
        /// </summary>
        void AbortRunningCommands();
    }
}
