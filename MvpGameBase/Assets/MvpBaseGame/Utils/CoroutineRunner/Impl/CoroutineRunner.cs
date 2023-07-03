using System.Collections;
using UnityEngine;

namespace MvpBaseGame.Utils.CoroutineRunner.Impl
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineRunner(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        
        public Coroutine StartCoroutine(IEnumerator enumerator)
        {
            if (_monoBehaviour)
            {
                return _monoBehaviour.StartCoroutine(enumerator);
            }

            return null;
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            if (_monoBehaviour)
            {
                _monoBehaviour.StopCoroutine(coroutine);
            }
        }
    }
}
