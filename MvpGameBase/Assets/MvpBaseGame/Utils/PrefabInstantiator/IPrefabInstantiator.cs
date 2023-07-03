using UnityEngine;

namespace MvpBaseGame.Utils.PrefabInstantiator
{
    public interface IPrefabInstantiator
    {

        /// <inheritdoc cref="Instantiate{T}(T)"/>
        /// <param name="parent">The parent to attach to.</param>
        /// <param name="worldPositionStays">Keep object local position after attaching to parent.</param>
        T Instantiate<T>(T original, Transform parent, bool worldPositionStays = false) where T : Object;

        /// <summary>
        /// Instantiate specified object.
        /// </summary>
        /// <param name="original">The object to instantiate.</param>
        /// <typeparam name="T">The type of object to instantiate.</typeparam>
        /// <returns>Returns instantiated object.</returns>
        T Instantiate<T>(T original) where T : Object;
    }
}