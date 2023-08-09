using MvpBaseGame.Mvp.Common.Services.Impl;
using MvpBaseGame.Mvp.Common.Services;
using UnityEngine;

namespace MvpBaseGame.Mvp.Common.Helpers
{
    public static class UnityHelper
    {
        private const string GameObjectName = "UnityLifecycle";
        
        public static IUnityLifecycle Instance => _instance ??= CreateInstance();
        private static IUnityLifecycle _instance;

        private static IUnityLifecycle CreateInstance()
        {
            var gameObject = GameObject.Find("/" + GameObjectName) ?? new GameObject(GameObjectName);
            return gameObject.AddComponent<UnityLifecycle>();
        }
    }
}
