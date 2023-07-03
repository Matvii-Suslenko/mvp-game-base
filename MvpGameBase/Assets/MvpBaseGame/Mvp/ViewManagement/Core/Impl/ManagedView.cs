using System;
using MvpBaseGame.Mvp.ViewManagement.Data;
using MvpBaseGame.Mvp.ViewManagement.Transitions;
using MvpBaseGame.Mvp.ViewManagement.Transitions.Impl;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Core.Impl
{
    public class ManagedView : MonoBehaviour, IMutableManagedView  
    {
        public event Action ViewClosed;

        public IViewDefinition ViewDef => _data.ViewDefinition;

        public IViewData Data => _data;
        public bool HasFocus => _hasFocus != null && _hasFocus.Value;
        
        public GameObject Current => gameObject;
        
        public ITransitionHandler Transition
        {
            get
            {
                if (_transition == null)
                {
                    _transition = CreateTransition();
                }
                return _transition;
            }
        }
        
        public bool IsInteractable { get; private set; } = true;
        
        private ITransitionInvoker _transition;

        private IViewData _data;
        private bool? _hasFocus;
        private bool _isClosing;

        protected virtual void Awake()
        {
            _transition = CreateTransition();
        }

        public void SetData(IViewData data)
        {
            _data = data;
        }

        public void SetFocus(bool hasFocus)
        {
            if (_hasFocus != hasFocus)
            {
                var isInit = _hasFocus == null;
                _hasFocus = hasFocus;
                if (!isInit)
                {
                    OnFocusChanged(_hasFocus.Value);
                }
            }
        }

        public virtual void StartTransitionIn()
        {
            _transition.PlayIn();
        }

        protected virtual ITransitionInvoker CreateTransition()
        {
            var transitionDecorator = new ViewTransitionDecorator(GetComponent<AbstractViewTransition>());
            return transitionDecorator;
        }

        protected virtual void OnInteractableChanged(bool isInteractable)
        {
            // for override
        }

        protected virtual void OnFocusChanged(bool hasFocus)
        {
            // for override 
        }

        public void SetInteractable(bool isInteractable)
        {
            IsInteractable = isInteractable;
            OnInteractableChanged(IsInteractable);
        }

        public virtual void CloseView(Action onCompleted = null)
        {
            if (onCompleted != null)
            {
                _transition.PlayOutCompleted += onCompleted.Invoke;
            }
            
            if (_isClosing)
            {
               Debug.LogWarning("Closing view already in progress");
                return;
            }
            _isClosing = true;
            StartTransitionOut();
        }
        
        protected virtual void StartTransitionOut()
        {
            SetInteractable(false);
            _transition.PlayOut(OnViewClosed);
        }
        
        private void OnViewClosed()
        {
            ViewClosed?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            _transition?.Dispose();
        }
    }
}