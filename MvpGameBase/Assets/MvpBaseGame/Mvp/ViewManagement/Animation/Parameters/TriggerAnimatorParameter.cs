using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Parameters
{
	[Serializable]
	public class TriggerAnimatorParameter : AnimatorParameter
	{
		public override AnimatorControllerParameterType Type => AnimatorControllerParameterType.Trigger;
	}
}
