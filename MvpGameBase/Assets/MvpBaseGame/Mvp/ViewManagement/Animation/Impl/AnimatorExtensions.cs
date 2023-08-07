using MvpBaseGame.Mvp.ViewManagement.Animation.Parameters;
using System.Collections.Generic;
using MvpBaseGame.Promises.Impl;
using MvpBaseGame.Promises;
using UnityEngine;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Impl
{
    public static class AnimatorExtensions
    {
        private static readonly Dictionary<AnimatorPromisesMapKey, Promise> AnimatorPromisesMap = new Dictionary<AnimatorPromisesMapKey, Promise>();

        public static IPromise CreateAnimatorPromise(this Animator animator, string eventName)
        {
            return CreateAnimatorPromise(animator, Animator.StringToHash(eventName));
        }

        public static IPromise CreateAnimatorPromise(this Animator animator, int eventHash)
        {
            var mappingKey = new AnimatorPromisesMapKey(animator, eventHash);
            
            if (AnimatorPromisesMap.ContainsKey(mappingKey))
            {
                return AnimatorPromisesMap[mappingKey];
            }
            
            var promise = new Promise();
            
            AnimatorPromisesMap.Add(mappingKey, promise);

            return promise;
        }

        public static void Dispatch(this Animator animator, int eventHash)
        {
            var mappingKey = new AnimatorPromisesMapKey(animator, eventHash);

            if (!AnimatorPromisesMap.ContainsKey(mappingKey))
            {
                return;
            }

            if (!AnimatorPromisesMap.TryGetValue(mappingKey, out var promise))
            {
                return;
            }
            
            promise.Dispatch();

            AnimatorPromisesMap.Remove(mappingKey);
        }

        public static void SetTrigger(this Animator anim, TriggerAnimatorParameter parameter)
        {
            anim.SetTrigger(parameter.Hash);
        }
        
        public static void ResetTrigger(this Animator anim, TriggerAnimatorParameter parameter)
        {
            anim.ResetTrigger(parameter.Hash);
        }

        public static void ResetAllTriggers(this Animator animator)
        {
            foreach (var trigger in animator.parameters)
            {
                if (trigger.type == AnimatorControllerParameterType.Trigger)
                {
                    animator.ResetTrigger(trigger.name);
                }
            }
        }

        public static void SetFloat(this Animator anim, FloatAnimatorParameter parameter, float value)
        {
            anim.SetFloat(parameter.Hash, value);
        }
        
        public static void SetBool(this Animator anim, BoolAnimatorParameter parameter, bool value)
        {
            anim.SetBool(parameter.Hash, value);
        }
        
        public static void ToggleBool(this Animator anim, BoolAnimatorParameter parameter)
        {
            var value = anim.GetBool(parameter);
            anim.SetBool(parameter, !value);
        }
        
        public static void SetInteger(this Animator anim, IntAnimatorParameter parameter, int value)
        {
            anim.SetInteger(parameter.Hash, value);
        }

        public static float GetFloat(this Animator anim, FloatAnimatorParameter parameter)
        {
            return anim.GetFloat(parameter.Hash);
        }
        
        public static bool GetBool(this Animator anim, BoolAnimatorParameter parameter)
        {
            return anim.GetBool(parameter.Hash);
        }
        
        public static int GetInteger(this Animator anim, IntAnimatorParameter parameter)
        {
            return anim.GetInteger(parameter.Hash);
        }

        private struct AnimatorPromisesMapKey
        {
            private readonly int AnimatorInstanceId;
            private readonly int AnimatorEventHash;

            public AnimatorPromisesMapKey(Animator animator, int animatorEventHash) : this(animator.GetInstanceID(),
                animatorEventHash) { }

            public AnimatorPromisesMapKey(int animatorInstanceId, int animatorEventHash)
            {
                AnimatorInstanceId = animatorInstanceId;
                AnimatorEventHash = animatorEventHash;
            }
            
            public bool Equals(AnimatorPromisesMapKey other)
            {
                return AnimatorInstanceId == other.AnimatorInstanceId && AnimatorEventHash == other.AnimatorEventHash;
            }

            public override bool Equals(object obj)
            {
                return obj is AnimatorPromisesMapKey other && Equals(other);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (AnimatorInstanceId * 397) ^ AnimatorEventHash;
                }
            }
        }
        
        public static void ResetParametersAnimator(this Animator animator, bool rebind)
        {
            AnimatorControllerParameter[] parameters = animator.parameters;
            foreach (var parameter in parameters)
            {
                switch (parameter.type)
                {
                    case AnimatorControllerParameterType.Int:
                        animator.SetInteger(parameter.name, parameter.defaultInt);
                        break;
                    case AnimatorControllerParameterType.Float:
                        animator.SetFloat(parameter.name, parameter.defaultFloat);
                        break;
                    case AnimatorControllerParameterType.Bool:
                        animator.SetBool(parameter.name, parameter.defaultBool);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        animator.ResetTrigger(parameter.name);
                        break;
                }
            }

            if (rebind)
            {
                animator.Rebind();
            }
        }
    }
}
