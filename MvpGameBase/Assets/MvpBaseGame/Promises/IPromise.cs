using System;

namespace MvpBaseGame.Promises
{
    public interface IPromise : IBasePromise
    {
        IPromise Then(Action action);

        void Dispatch();

        void RemoveListener(Action action);

        void RemoveListeners();
    }
    
    public interface IPromise<T> : IBasePromise
    {
        IPromise<T> Then(Action<T> action);

        void Dispatch(T t);

        void RemoveListener(Action<T> action);

        void RemoveListeners();
    }
}