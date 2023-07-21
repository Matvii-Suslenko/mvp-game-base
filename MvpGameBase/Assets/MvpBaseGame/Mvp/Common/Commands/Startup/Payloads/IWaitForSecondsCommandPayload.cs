namespace MvpBaseGame.Mvp.Common.Commands.Startup.Payloads
{
    public interface IWaitForSecondsCommandPayload
    {
        /// <summary>
        /// Seconds to Wait
        /// </summary>
        float Seconds { get; }
    }
}
