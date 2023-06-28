using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    public class CommandAbortedException : Exception
    {
        public Type Type { get; }

        public CommandAbortedException(Type commandType, Exception innerException = null): base($"Command Aborted: {commandType.FullName}", innerException)
        {
            Type = commandType;
        }
    }
}
