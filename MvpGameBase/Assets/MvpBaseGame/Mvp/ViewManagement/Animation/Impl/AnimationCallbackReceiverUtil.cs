using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.ViewManagement.Animation.Impl
{
    public static class AnimationCallbackReceiverUtil
    {
        public enum ComponentSearchLocation
        {
            Attached = 0,
            Parent = 1,
            Child = 2,
        }

        private static Func<Component, TSearchComponentType> SearchFunctor<TSearchComponentType>(ComponentSearchLocation searchLocation) 
        {
            switch (searchLocation)
            {
                case ComponentSearchLocation.Attached:
                    return component => component.GetComponent<TSearchComponentType>();

                case ComponentSearchLocation.Parent:
                {
                    return component =>
                    {
                        var compTransform = component.transform;
                        var compTransformParent = compTransform.parent;
                        var searchRoot = compTransformParent == null ? compTransform : compTransformParent;
                      
                        return searchRoot.GetComponentInParent<TSearchComponentType>();
                    };
                }

                case ComponentSearchLocation.Child:
                {
                    return component =>
                    {
                        var searchRoot = component.transform;

                        foreach (Transform child in searchRoot)
                        {
                            var match = child.GetComponentInChildren<TSearchComponentType>();

                            if (match != null)
                            {
                                return match;
                            }
                        }

                        return default(TSearchComponentType);
                    };
                }
                
                default:
                    throw new ArgumentOutOfRangeException("searchLocation", searchLocation, null);
            }
        }

        public static bool IsValid<TTriggers>(Component component, ComponentSearchLocation searchLocation, ref IAnimationCallbackReceiver<TTriggers> animationCallbackReceiver)
        {
            if (animationCallbackReceiver != null)
            {
                return true;
            }

            var searcher = SearchFunctor<IAnimationCallbackReceiver<TTriggers>>(searchLocation);

            animationCallbackReceiver = searcher(component);

            bool result = animationCallbackReceiver != null;

            if (!result)
            {
                
                UnityEngine.Debug.LogWarningFormat("Component {0} on {1} isn't valid. Cannot find {2} instance of: {3}", 
                    typeof(IAnimationCallbackReceiver<TTriggers>),
                    component.GetType(),
                    searchLocation.ToString().ToLower(),
                    component.name);
            }

            return result;
        }
    }
}
