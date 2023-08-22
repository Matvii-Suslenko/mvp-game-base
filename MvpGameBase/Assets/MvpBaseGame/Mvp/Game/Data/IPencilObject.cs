using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Data
{
    public interface IPencilObject
    {
        float RotationFading { set; }
        float MinimumRotation { set; }
        float MaximumRotation { set; }
        
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
