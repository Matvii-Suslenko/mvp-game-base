using MvpBaseGame.Promises.Impl;
using System;

namespace MvpBaseGame.Promises
{
    public interface IBasePromise
    {
        bool CanBeAborted { get; }

        bool Aborted { get; }

        IBasePromise Progress(Action<float> listener);

        IBasePromise Fail(Action<Exception> listener);

        IBasePromise Finally(Action listener);

        void ReportFail(Exception ex);

        void ReportProgress(float progress);

        void RemoveAllListeners();

        void RemoveProgressListener(Action<float> listener);

        void RemoveProgressListeners();

        void RemoveFailListener(Action<Exception> listener);

        void RemoveFailListeners();

        void RemoveFinallyListener(Action listener);

        void RemoveFinallyListeners();

        int ListenerCount();

        void Abort(string message = null, Exception innerException = null);

        BasePromise.PromiseState State { get; }

        float CurrentProgress { get; }
    }
}
