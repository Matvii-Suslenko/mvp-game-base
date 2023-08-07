using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Parameters
{
	[Serializable]
	public class FloatAnimatorParameter : AnimatorParameter
	{
		public override AnimatorControllerParameterType Type => AnimatorControllerParameterType.Float;
	}
}
