namespace MvpBaseGame.Mvp.Common.Commands.Startup.Payloads.Impl
{
    public class WaitForSecondsCommandPayload : IWaitForSecondsCommandPayload
    {
        public float Seconds { get; }

        public WaitForSecondsCommandPayload(float seconds)
        {
            Seconds = seconds;
        }
    }
}
