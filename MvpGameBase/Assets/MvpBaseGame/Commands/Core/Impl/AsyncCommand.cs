using MvpBaseGame.Promises;

namespace MvpBaseGame.Commands.Core.Impl
{
    public abstract class AsyncCommand : AsyncBaseCommand
    {
        public sealed override IPromise Execute(ICommandPayload args)
        {
            Execute();
            return Outcome;
        }

        protected abstract void Execute();
    }

    public abstract class AsyncCommand<T> : AsyncBaseCommand
    {
        public sealed override IPromise Execute(ICommandPayload args)
        {
            Execute((T) args);
            return Outcome;
        }

        protected abstract void Execute(T value);
    }
}