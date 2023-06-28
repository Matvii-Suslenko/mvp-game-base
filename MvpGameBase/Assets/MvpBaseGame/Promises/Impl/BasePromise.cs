using System.Collections.Generic;
using MvpBaseGame.Extensions;
using System.Linq;
using System;

namespace MvpBaseGame.Promises.Impl
{
  public abstract class BasePromise : IBasePromise
  {
    private readonly Action _abortAction;
    private Exception _exception;
    public static Action<Exception> OnCallbackException;

    private event Action<float> OnProgress;

    private event Action<Exception> OnFail;

    private event Action OnFinally;
    public BasePromise.PromiseState State { get; protected set; }

    public float CurrentProgress { get; private set; }

    protected BasePromise(Action abortAction, TimeSpan timeout, bool executeOnMain)
    {
      this.State = BasePromise.PromiseState.Pending;
      this._abortAction = abortAction;
    }

    public bool CanBeAborted => this._abortAction != null;

    public bool Aborted { get; private set; }

    public void ReportFail(Exception ex)
    {
      if (this.Resolved)
        return;
      this._exception = ex;
      this.State = BasePromise.PromiseState.Failed;
      if (this.OnFail != null)
        this.OnFail.SafeInvoke<Exception>(ex, BasePromise.OnCallbackException);
      this.Finally();
    }

    public void ReportProgress(float progress)
    {
      if (this.Resolved)
        return;
      this.CurrentProgress = progress;
      if (this.OnProgress == null)
        return;
      this.OnProgress.SafeInvoke<float>(progress, BasePromise.OnCallbackException);
    }

    protected bool Fulfill()
    {
      if (this.Resolved)
        return false;
      this.CurrentProgress = 1f;
      this.State = BasePromise.PromiseState.Fulfilled;
      return true;
    }

    public IBasePromise Progress(Action<float> listener)
    {
      this.OnProgress = this.AddUnique<float>(this.OnProgress, listener);
      return (IBasePromise) this;
    }

    public IBasePromise Fail(Action<Exception> listener)
    {
      if (this.Failed)
        listener.SafeInvoke<Exception>(this._exception, BasePromise.OnCallbackException);
      else
        this.OnFail = this.AddUnique<Exception>(this.OnFail, listener);
      return (IBasePromise) this;
    }

    public IBasePromise Finally(Action listener)
    {
      if (this.Resolved)
        listener.SafeInvoke(BasePromise.OnCallbackException);
      else
        this.OnFinally = this.AddUnique(this.OnFinally, listener);
      return (IBasePromise) this;
    }

    protected void Finally()
    {
      if (this.OnFinally != null)
        this.OnFinally.SafeInvoke(BasePromise.OnCallbackException);
      this.RemoveAllListeners();
    }

    public void RemoveProgressListener(Action<float> listener)
    {
      if (this.OnProgress == null)
        return;
      this.OnProgress -= listener;
    }

    public void RemoveProgressListeners() => this.OnProgress = (Action<float>) null;

    public void RemoveFailListener(Action<Exception> listener)
    {
      if (this.OnFail == null)
        return;
      this.OnFail -= listener;
    }

    public void RemoveFailListeners() => this.OnFail = (Action<Exception>) null;

    public void RemoveFinallyListener(Action listener)
    {
      if (this.OnFinally == null)
        return;
      this.OnFinally -= listener;
    }

    public void RemoveFinallyListeners() => this.OnFinally = (Action) null;

    public virtual void RemoveAllListeners()
    {
      this.OnProgress = (Action<float>) null;
      this.OnFail = (Action<Exception>) null;
      this.OnFinally = (Action) null;
    }

    protected Action AddUnique(Action listeners, Action callback)
    {
      if (listeners == null || !((IEnumerable<Delegate>) listeners.GetInvocationList()).Contains<Delegate>((Delegate) callback))
        listeners += callback;
      return listeners;
    }

    protected Action<T> AddUnique<T>(Action<T> listeners, Action<T> callback)
    {
      if (listeners == null || !((IEnumerable<Delegate>) listeners.GetInvocationList()).Contains<Delegate>((Delegate) callback))
        listeners += callback;
      return listeners;
    }

    protected bool Pending => this.State == BasePromise.PromiseState.Pending;

    protected bool Resolved => this.State != BasePromise.PromiseState.Pending;

    protected bool Fulfilled => this.State == BasePromise.PromiseState.Fulfilled;

    protected bool Failed => this.State == BasePromise.PromiseState.Failed;

    public abstract int ListenerCount();

    public void Abort(string message = null, Exception innerException = null)
    {
      if (this.Resolved)
        return;
      this.ReportFail((Exception) new OperationAbortedException(message, innerException));
      this.Aborted = true;
      this.OnAbort(message, innerException);
    }

    protected virtual void OnAbort(string message, Exception innerException)
    {
      if (this._abortAction == null)
        return;
      this._abortAction();
    }

    public enum PromiseState
    {
      Fulfilled,
      Failed,
      Pending,
    }
  }
}
