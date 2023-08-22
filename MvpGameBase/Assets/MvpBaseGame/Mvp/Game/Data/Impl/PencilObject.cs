using UnityEngine;

namespace MvpBaseGame.Mvp.Game.Data.Impl
{
    public class PencilObject : MonoBehaviour, IPencilObject
    {
        public float RotationFading { private get; set; }
        public float MinimumRotation { private get; set; }
        public float MaximumRotation { private get; set; }
        
        [SerializeField]
        private GameObject _pencilModel;

        private float _anglesAim;

        public void Rotate(float angles)
        {
            _anglesAim = Mathf.Clamp(_anglesAim + angles, MinimumRotation, MaximumRotation);
        }

        public void Move(Vector3 movement)
        {
            gameObject.transform.position += movement;
        }

        private void Update()
        {
            _pencilModel.transform.localRotation = Quaternion.Euler(0, 0, _anglesAim);

            if (_anglesAim < -RotationFading)
            {
                _anglesAim += RotationFading;
            }
            else if (_anglesAim > RotationFading)
            {
                _anglesAim -= RotationFading;
            }
        }
    }
}
