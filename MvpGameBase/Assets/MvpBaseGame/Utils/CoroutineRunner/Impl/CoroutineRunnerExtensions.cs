using System.Collections;
using UnityEngine;
using System;

namespace MvpBaseGame.Utils.CoroutineRunner.Impl
{
    public static class CoroutineRunnerExtensions
    {
        public static Coroutine AfterFrame(this ICoroutineRunner coroutineRunner, Action callback)
        {
            return coroutineRunner.StartCoroutine(ScheduleAfterFrame(callback));
        }

        public static Coroutine AfterSeconds(this ICoroutineRunner coroutineRunner, float delay, Action callback)
        {
            return coroutineRunner.StartCoroutine(ScheduleAfterSeconds(delay, callback));
        }

        public static Coroutine NextFrame(this ICoroutineRunner coroutineRunner, Action callback)
        {
            return coroutineRunner.StartCoroutine(ScheduleNextFrame(callback));
        }
        
        private static IEnumerator ScheduleAfterFrame(Action callback)
        {
            yield return new WaitForEndOfFrame();

            callback();
        }

        private static IEnumerator ScheduleAfterSeconds(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);

            callback();
        }

        private static IEnumerator ScheduleNextFrame(Action callback)
        {
            yield return null;
            
            callback();
        }
    }
}
