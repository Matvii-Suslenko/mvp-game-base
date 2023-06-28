using MvpBaseGame.Promises.Impl;
using MvpBaseGame.Promises;
using UnityEngine;
using System;

namespace MvpBaseGame.Commands.Core.Impl
{
    public abstract class Command : ICommand
    {
        public IPromise Execute(ICommandPayload args)
        {
            var promise = new Promise();
            try
            {
                Execute();
                promise.Dispatch();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                promise.ReportFail(e);
                throw;
            }
          
            return promise;
        }
        
        protected abstract void Execute();
        
        public virtual void Dispose()
        {
           
        }
    }
    
    public abstract class Command<T> : ICommand, ICommand<T> where T : ICommandPayload
    {
        public IPromise Execute(ICommandPayload args)
        {
            var promise = new Promise();
            try
            {
                Execute((T)args);
                promise.Dispatch();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                promise.ReportFail(e);
                throw;
            }
            return promise;
        }

        protected abstract void Execute(T value);
        
        public virtual void Dispose()
        {
           
        }
    }
}
