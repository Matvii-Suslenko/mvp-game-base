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
}