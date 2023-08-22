using System;

namespace MvpBaseGame.Mvp.Common.Components.DragZone
{
    public interface IOneDimensionalDragZone
    {
        /// <summary>
        /// Fires on Drag
        /// </summary>
        event Action<float> Drag;
    }
}
