using Object = UnityEngine.Object;
using UnityEngine;
using Zenject;
using System;

namespace MvpBaseGame.Utils.PrefabInstantiator.Impl
{
    public class PrefabInstantiator : IPrefabInstantiator
    {
        private readonly IInstantiator _instantiator;

        public PrefabInstantiator(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public virtual T Instantiate<T>(T original, Transform parent, bool worldPositionStays = false) where T : Object
        {
            if (original is GameObject gameObj)
            {
                var obj = _instantiator.InstantiatePrefab(gameObj, parent);
                if (worldPositionStays)
                {
                    obj.transform.localPosition = gameObj.transform.position;
                }

                return obj as T;
            }
            if (original is Component comp)
            {
                var obj = _instantiator.InstantiatePrefab(comp.gameObject, parent).GetComponent<T>();
                var instantiatedComp = obj as Component;
                if (worldPositionStays)
                {
                    instantiatedComp!.transform.localPosition = comp.transform.position;
                }

                return obj;
            }

            throw new Exception("Unknown object type.");
        }

        public virtual T Instantiate<T>(T original) where T : Object
        {
            if (original is Component originComp)
            {
                var comp = _instantiator.InstantiatePrefab(originComp.gameObject).GetComponent<T>();
                return comp;
            }


            if (original is GameObject)
            {
                var gamObj = _instantiator.InstantiatePrefab(original);
                return gamObj as T;
            }
            throw new InvalidOperationException("Unknown type to instantiate");
        }
    }
}