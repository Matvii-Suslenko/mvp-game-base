using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Parameters
{
	[Serializable]
	public class IntAnimatorParameter : AnimatorParameter
	{
		public override AnimatorControllerParameterType Type => AnimatorControllerParameterType.Int;
	}
}
