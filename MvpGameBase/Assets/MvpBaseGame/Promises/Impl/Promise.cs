using MvpBaseGame.Extensions;
using System;

namespace MvpBaseGame.Promises.Impl
{
    public class Promise : BasePromise, IPromise, IBasePromise
    {
        protected event Action Listener;

        public void Dispatch()
        {
            if (!this.Fulfill())
                return;
            this.CallListener();
            this.Finally();
        }

        public IPromise Then(Action action)
        {
            if (this.Fulfilled)
            {
                action.SafeInvoke(BasePromise.OnCallbackException);
                this.Finally();
            }
            else if (this.Pending)
                this.Listener = this.AddUnique(this.Listener, action);
            return (IPromise) this;
        }

        public void RemoveListener(Action action)
        {
            if (this.Listener == null)
                return;
            this.Listener -= action;
        }

        public void RemoveListeners() => this.Listener = (Action) null;

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();
            this.Listener = (Action) null;
        }

        public override int ListenerCount() => this.Listener != null ? this.Listener.GetInvocationList().Length : 0;

        private void CallListener()
        {
            if (this.Listener == null)
                return;
            this.Listener.SafeInvoke(BasePromise.OnCallbackException);
        }

        public Promise(Action abortAction)
            : base(abortAction, TimeSpan.Zero, true)
        {
        }

        public Promise(TimeSpan timeout, Action abortAction = null, bool executeOnMainThread = true)
            : base(abortAction, timeout, executeOnMainThread)
        {
        }

        public Promise()
            : this((Action) null)
        {
        }
    }
    
    public class Promise<T> : BasePromise, IPromise<T>, IBasePromise
    {
        private T t;

        protected event Action<T> Listener;

        public void Dispatch(T t)
        {
            if (!this.Fulfill())
                return;
            this.t = t;
            this.CallListener();
            this.Finally();
        }

        public IPromise<T> Then(Action<T> action)
        {
            if (this.Fulfilled)
            {
                action.SafeInvoke<T>(this.t, BasePromise.OnCallbackException);
                this.Finally();
            }
            else if (this.Pending)
                this.Listener = this.AddUnique<T>(this.Listener, action);
            return (IPromise<T>) this;
        }

        public void RemoveListener(Action<T> action)
        {
            if (this.Listener == null)
                return;
            this.Listener -= action;
        }

        public void RemoveListeners() => this.Listener = (Action<T>) null;

        public override void RemoveAllListeners()
        {
            base.RemoveAllListeners();
            this.Listener = (Action<T>) null;
        }

        public override int ListenerCount() => this.Listener != null ? this.Listener.GetInvocationList().Length : 0;

        private void CallListener()
        {
            if (this.Listener == null)
                return;
            this.Listener.SafeInvoke<T>(this.t, BasePromise.OnCallbackException);
        }

        public Promise(Action abortAction)
            : base(abortAction, TimeSpan.Zero, true)
        {
        }

        public Promise(TimeSpan timeout, Action abortAction = null, bool executeOnMainThread = true)
            : base(abortAction, timeout, executeOnMainThread)
        {
        }

        public Promise()
            : this((Action) null)
        {
        }
    }
}
