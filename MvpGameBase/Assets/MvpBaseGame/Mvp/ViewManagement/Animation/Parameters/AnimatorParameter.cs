using Object = UnityEngine.Object;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Parameters
{
	[Serializable]
	public abstract class AnimatorParameter
	{
		private int _hash = int.MaxValue;
		
		[SerializeField] private string _name;
		[SerializeField] private Object _animatorOverride;
        
		public abstract AnimatorControllerParameterType Type { get; }


		public int Hash => _hash != int.MaxValue ? _hash : _hash = Animator.StringToHash(_name);
	}
}
