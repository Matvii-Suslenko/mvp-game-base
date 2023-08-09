using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Services.Impl
{
    public class UnityLifecycle : MonoBehaviour, IUnityLifecycle
    {
        public event Action<float> Updated;
        public event Action Started;
        public event Action LateUpdated;
        public event Action Quited;
        public event Action<bool> Paused;
        public event Action<bool> FocusChanged;

        private void Awake()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this);
            }
        }

        private void Start()
        {
            Started?.Invoke();
        }
        
        private void Update()
        {
            Updated?.Invoke(Time.deltaTime);
        }

        private void LateUpdate()
        {
            LateUpdated?.Invoke();
        }

        private void OnApplicationQuit()
        {
            Quited?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            Paused?.Invoke(pauseStatus);
        }
        
        private void OnApplicationFocus(bool pauseStatus)
        {
            FocusChanged?.Invoke(pauseStatus);
        }
    }
}
