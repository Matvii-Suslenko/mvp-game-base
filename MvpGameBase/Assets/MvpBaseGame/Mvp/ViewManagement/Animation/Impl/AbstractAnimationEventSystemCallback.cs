using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Impl
{
	public class AbstractAnimationEventSystemCallback<TTriggers> : StateMachineBehaviour where TTriggers : struct, IConvertible, IFormattable, IComparable
	{
		[SerializeField] private bool _isActiveEnter;
		[SerializeField] private bool _isActiveEnd;
		[SerializeField] private bool _isActiveExit;

		[SerializeField] private TTriggers _enterTrigger;
		[SerializeField] private TTriggers _endTrigger;
		[SerializeField] private TTriggers _exitTrigger;

		public bool IsActiveEnter => _isActiveEnter;
		public bool IsActiveEnd => _isActiveEnd;
		public bool IsActiveExit => _isActiveExit;

		public TTriggers EnterTrigger => _enterTrigger;
		public TTriggers EndTrigger => _endTrigger;
		public TTriggers ExitTrigger => _exitTrigger;

		private IAnimationCallbackReceiver<TTriggers> _animationCallbackReceiver;

		private bool _endTriggerDispatched;

		private bool IsValid(Animator animator)
		{
			return AnimationCallbackReceiverUtil.IsValid(animator, AnimationCallbackReceiverUtil.ComponentSearchLocation.Attached, ref _animationCallbackReceiver);
		}

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
		{
			if (IsValid(animator))
			{
				TryAndPublishTrigger(_isActiveEnter, _enterTrigger);
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (_endTriggerDispatched)
			{
				return;
			}

			if (stateInfo.normalizedTime < 1f && !Mathf.Approximately(stateInfo.normalizedTime, 1f))
			{
				return;
			}

			if (!IsValid(animator))
			{
				return;
			}
			
			TryAndPublishTrigger(_isActiveEnd, _endTrigger, true);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
		{
			if (IsValid(animator))
			{
				if (!_endTriggerDispatched && _isActiveEnd)
				{
					TryAndPublishTrigger(_isActiveEnd, _endTrigger, true);
				}
		
				TryAndPublishTrigger(_isActiveExit, _exitTrigger);
			}

			Reset();
		}

		private void Reset()
		{
			_endTriggerDispatched = false;
		}

		private void TryAndPublishTrigger(bool isTriggerActive, TTriggers trigger, bool isEndTrigger = false)
		{
			if (isTriggerActive)
			{
				if (isEndTrigger)
				{
					_endTriggerDispatched = true;
				}

				_animationCallbackReceiver.AnimationEventCallBack(trigger);
			}
		}
	}
}
