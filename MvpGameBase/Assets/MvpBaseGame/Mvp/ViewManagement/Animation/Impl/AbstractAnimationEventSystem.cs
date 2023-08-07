using MvpBaseGame.Mvp.ViewManagement.Animation.Parameters;
using System.Collections.Generic;
using MvpBaseGame.Promises.Impl;
using MvpBaseGame.Extensions;
using MvpBaseGame.Promises;
using System.Linq;
using UnityEngine;
using ModestTree;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Impl
{
    [RequireComponent(typeof(Animator))]
    public abstract class AbstractAnimationEventSystem <TTriggers> : MonoBehaviour,
                                                                     IAnimationEventSystem<TTriggers>
                                                                     where TTriggers: struct, IFormattable, IConvertible, IComparable
    {
        private Animator _animator;
        protected Animator Animator => _animator != null ? _animator : _animator = GetComponent<Animator>();

        private IDictionary<TTriggers,Action> _animationEvents;
        private IDictionary<TTriggers,Action> AnimationEvents => _animationEvents ?? (_animationEvents = GenerateAnimationEvents());

        private IDictionary<TTriggers, Action> GenerateAnimationEvents()
        {
            return CSharpExtensions.GetEnumValues<TTriggers>().ToDictionary<TTriggers, TTriggers, Action>(triggerName => triggerName, triggerName => null);
        }

        public void SetAnimationCallback(TTriggers triggerName, Action animationEventCallback)
        {
            if (animationEventCallback != null)
            {
                AnimationEvents[triggerName] = animationEventCallback;
            }
        }

        public void ClearAnimationCallback(TTriggers triggerName)
        {
            AnimationEvents[triggerName] = null;
        }

        public IPromise SetPromiseTrigger(TTriggers trigger, bool resetAnimator = false)
        {
            var promise = new Promise();
            SetTrigger(trigger, promise.Dispatch, resetAnimator);
            return promise;
        }
        
        public void SetTrigger(TTriggers trigger, Action animationEventCallback = null, bool resetAnimator = false)
        {
            ModifyAnimatorParameter(
                () => Animator.SetTrigger(trigger.ToString()),
                trigger, 
                animationEventCallback, 
                resetAnimator);
        }
        
        public void SetTrigger(TriggerAnimatorParameter parameter)
        {
            Animator.SetTrigger(parameter);
        }
        public void SetTrigger(int parameter)
        {
            Animator.SetTrigger(parameter);
        }

        public void SetBool(TTriggers boolName, bool value, Action animationEventCallback, bool resetAnimator = false)
        {
            ModifyAnimatorParameter(
                () => Animator.SetBool(boolName.ToString(), value),
                boolName, 
                animationEventCallback, 
                resetAnimator);
        }

        public void SetBool(TTriggers boolName, bool value)
        {
            Animator.SetBool(boolName.ToString(), value);
        }
        
        public void SetBool(int id, bool value)
        {
            Animator.SetBool(id, value);
        }
        
        public void SetBool(BoolAnimatorParameter id, bool value)
        {
            Animator.SetBool(id, value);
        }
        
        public void SetInteger(int id, int value)
        {
            Animator.SetInteger(id, value);
        }
        
        public void SetInteger(IntAnimatorParameter id, int value)
        {
            Animator.SetInteger(id, value);
        }
        
        public void SetFloat(FloatAnimatorParameter id, float value)
        {
            Animator.SetFloat(id, value);
        }
        
        private void ModifyAnimatorParameter(Action parameterModifier, TTriggers trigger, Action animationEventCallback = null, bool resetAnimator = false)
        {
            if (resetAnimator)
            {
                ResetAnimator();
            }

            SetAnimationCallback(trigger, animationEventCallback);

            parameterModifier();

            if(animationEventCallback==null)
            {
                Log.Debug("AnimationEvent CallBack from {0} has not been defined",trigger.ToString());
            }
        }

        public virtual void AnimationEventCallBack(TTriggers trigger)
        {
            Action handler;
            if (AnimationEvents.TryGetValue(trigger, out handler) && handler != null)
            {
                handler.Invoke();
            }
            else
            {
                Log.Debug($"AnimationEvent CallBack from {trigger.ToString()} has not been defined");
            }
        }

        public void ResetAnimator(bool rebind = false)
        {
            Animator.ResetParametersAnimator(rebind);
        }

        public void ResetTrigger(TTriggers trigger)
        {
            Animator.ResetTrigger(trigger.ToString());
        }
        
        public void ResetAllTriggers()
        {
            Animator.ResetAllTriggers();
        }
        
        public void SkipAnimation(int layer = 0, float updateSeconds = 100f)
        {
            var animator = Animator;
            bool loopAgain = false;
            var prevStateHash = animator.GetCurrentAnimatorStateInfo(layer).shortNameHash;
            
            do
            {
                animator.Update(updateSeconds);
                
                var currentStateHash = animator.GetCurrentAnimatorStateInfo(layer).shortNameHash;
                loopAgain = prevStateHash != currentStateHash;
                prevStateHash = currentStateHash;
                
            } while (loopAgain);
        }
    }
}


