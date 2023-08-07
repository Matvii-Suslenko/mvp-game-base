using MvpBaseGame.Promises;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation
{
    public interface IAnimationEventSystem<TTriggers> : IAnimationCallbackReceiver<TTriggers>
    {
        /// <summary>
        /// Set Trigger parameter and return a promise subscribed as a callback 
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="resetAnimator"></param>
        /// <returns></returns>
        IPromise SetPromiseTrigger(TTriggers trigger, bool resetAnimator = false);
        
        /// <summary>
        /// Set Trigger parameter and associate an animation callback
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="animationEventCallback"></param>
        /// <param name="resetAnimator"></param>
        void SetTrigger(TTriggers trigger, Action animationEventCallback = null, bool resetAnimator = false);
        
        /// <summary>
        /// Set a boolean parameter value and associate an animation event callback
        /// </summary>
        /// <param name="boolName"></param>
        /// <param name="value"></param>
        /// <param name="animationEventCallback"></param>
        /// <param name="resetAnimator"></param>
        void SetBool(TTriggers boolName, bool value, Action animationEventCallback, bool resetAnimator = false);
        
        /// <summary>
        /// Set boolean parameter value
        /// </summary>
        /// <param name="boolName"></param>
        /// <param name="value"></param>
        void SetBool(TTriggers boolName, bool value);
        
        /// <summary>
        /// Reset single trigger parameter
        /// </summary>
        /// <param name="trigger"></param>
        void ResetTrigger(TTriggers trigger);

        /// <summary>
        /// Reset All parameters of type trigger
        /// </summary>
        void ResetAllTriggers();
        
        /// <summary>
        /// Update animator until doesn't change states.
        /// </summary>
        /// <param name="animator">Animator to update</param>
        /// <param name="layer">Layer to check for changes</param>
        /// <param name="updateSeconds">seconds to skip on each update</param>
        void SkipAnimation(int layer = 0, float updateSeconds = 100f);
    }
}
