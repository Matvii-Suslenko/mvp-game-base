using MvpBaseGame.Mvp.Game.Components;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Game.Data
{
    public interface IPencilObject
    {
        /// <summary>
        /// Fires on Task Found
        /// </summary>
        event Action<ITaskSticker> TaskFound;
        
        float RotationFading { set; }
        float MinimumRotation { set; }
        float MaximumRotation { set; }
        bool IsGrounded { get; }
        
        /// <summary>
        /// Moves Pencil
        /// </summary>
        /// <param name="movement">Movement Vector</param>
        void Move(Vector3 movement);

        /// <summary>
        /// Rotates Pencil
        /// </summary>
        /// <param name="angles">Angles to Rotate</param>
        void Rotate(float angles);

        /// <summary>
        /// Sets Pencil Length
        /// </summary>
        /// <param name="length"></param>
        void SetLength(float length);

        /// <summary>
        /// Sets Pencil Position
        /// </summary>
        /// <param name="position">Position</param>
        void SetPosition(Vector3 position);
    }
}
