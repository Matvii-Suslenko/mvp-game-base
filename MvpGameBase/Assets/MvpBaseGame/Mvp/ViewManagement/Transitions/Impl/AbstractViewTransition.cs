using System;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Transitions.Impl
{
    public abstract class AbstractViewTransition : MonoBehaviour, IViewTransition
    {
        public abstract void PlayIn(Action onComplete);
        public abstract void PlayOut(Action onComplete);
    }
}