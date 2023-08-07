using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Parameters
{
	[Serializable]
	public class BoolAnimatorParameter : AnimatorParameter
	{
		public override AnimatorControllerParameterType Type => AnimatorControllerParameterType.Bool;
	}
}