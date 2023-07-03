using System;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions.Impl
{
    public class ViewTransitionDecorator : ITransitionInvoker
    {
        public event Action PlayOutStarted;
        public event Action PlayInStarted;
        public event Action PlayInCompleted;
        public event Action PlayOutCompleted;
        
        private bool HasTransition => _viewTransition != null;
        
        private readonly IViewTransition _viewTransition;

        public bool IsPlayInComplete { get; private set; }

        public ViewTransitionDecorator(IViewTransition viewTransition)
        {
            _viewTransition = viewTransition;
        }

        public void PlayIn()
        {
            OnPlayInStart();

            if (HasTransition)
            {
                _viewTransition.PlayIn(OnPlayInCompleted);
            }
            else
            {
                OnPlayInCompleted();
            }
        }
        
        public void PlayOut(Action onCompleted)
        {
            OnPlayOutStart();
            
            if (HasTransition)
            {
                _viewTransition.PlayOut(() => OnPlayOutCompleted(onCompleted));
            }
            else
            {
                OnPlayOutCompleted(onCompleted);
            }
        }

        private void OnPlayInStart()
        {
            PlayInStarted?.Invoke();
        }

        private void OnPlayInCompleted()
        {
            IsPlayInComplete = true;
            PlayInCompleted?.Invoke();
        }

        private void OnPlayOutStart()
        {
            PlayOutStarted?.Invoke();
        }

        private void OnPlayOutCompleted(Action onCompleted)
        {
            PlayOutCompleted?.Invoke();
            onCompleted?.Invoke();
        }
        
        public void Dispose()
        {
            PlayOutStarted = null;
            PlayOutCompleted = null;
            PlayInStarted = null;
            PlayInCompleted = null;
        }
    }
}