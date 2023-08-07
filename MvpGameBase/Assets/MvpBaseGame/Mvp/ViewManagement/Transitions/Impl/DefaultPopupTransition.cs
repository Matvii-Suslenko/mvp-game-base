using UnityEngine;
using Zenject;
using System;
using MvpBaseGame.Mvp.ViewManagement.Animation.Impl;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions.Impl
{
    [RequireComponent(typeof(WindowAnimationManager))]
    public class DefaultPopupTransition : AbstractViewTransition
    {
        private WindowAnimationManager _animatorSystem;

        private void Awake()
        {
            _animatorSystem = GetComponent<WindowAnimationManager>();
        }
        
        public override void PlayIn(Action onComplete)
        {
            _animatorSystem.SetAnimationCallback(WindowAnimationState.PlayIn, onComplete);
        }
        
        public override void PlayOut(Action onComplete)
        {
            _animatorSystem.SetTrigger(WindowAnimationState.PlayOut, onComplete);
        }
    }
}