using MvpBaseGame.Promises.Impl;
using System;
using MvpBaseGame.Promises;

namespace MvpBaseGame.Commands.Core.Impl
{
    public abstract class AsyncBaseCommand : ICommand, IAbortable
    {
        protected readonly IPromise Outcome = new Promise();
        public abstract IPromise Execute(ICommandPayload args);
        
        protected void Release()
        {
            Outcome.Dispatch();
        }

        public void Abort(Exception exception = null)
        {
            Outcome.ReportFail(new CommandAbortedException(GetType(), exception));
        }

        public virtual void Dispose()
        {
            Outcome.RemoveAllListeners();
        }
    }
}