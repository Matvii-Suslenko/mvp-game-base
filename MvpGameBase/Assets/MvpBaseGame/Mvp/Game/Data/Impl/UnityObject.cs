using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Data.Impl
{
    public class UnityObject : IUnityObject
    {
        public static UnityObject WithTag(string tag)
        {
            var unityObject = new UnityObject();
            unityObject.FindByTag(tag);
            return unityObject;
        }
        
        private GameObject _gameObject;

        private UnityObject()
        {
        }

        public void MoveForward(float distance)
        {
            _gameObject.transform.position += Vector3.forward * distance;
        }

        private void FindByTag(string tag)
        {
            _gameObject = GameObject.FindWithTag(tag);
        }
    }
}
