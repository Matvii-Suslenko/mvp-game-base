using MvpBaseGame.Mvp.Game.Components;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Game.Data.Impl
{
    public class PencilObject : MonoBehaviour, IPencilObject
    {
        public event Action<ITaskSticker> TaskFound;
        
        public float RotationFading { private get; set; }
        public float MinimumRotation { private get; set; }
        public float MaximumRotation { private get; set; }
        public bool IsGrounded => _controller.isGrounded;

        [SerializeField]
        private CharacterController _controller;
        
        [SerializeField]
        private TrailRenderer _trailRenderer;
        
        [SerializeField]
        private GameObject _pencilModel;
        
        [SerializeField]
        private Transform _mainScalablePart;
        
        [SerializeField]
        private Transform _tailPart;
        
        [SerializeField]
        private Transform _tipPart;

        private IList<ITaskSticker> _seenStickers = new List<ITaskSticker>();
        private float _anglesAim;

        public void Rotate(float angles)
        {
            _anglesAim = Mathf.Clamp(_anglesAim + angles, MinimumRotation, MaximumRotation);
        }

        public void SetLength(float length)
        {
            // 0.155f  - top point
            // 0.015f  - main part end
            // 0.002f  - end

            var mainPartLeft = Mathf.Clamp((length - 0.1f) * 1.1f, 0, 1);
            var tipLeft = mainPartLeft > 0 ? 1 : length * 10f;
            
            _mainScalablePart.localScale = new Vector3(1, mainPartLeft, 1);
            _mainScalablePart.gameObject.SetActive(mainPartLeft > 0);
            _tailPart.localPosition = Vector3.up * (0.002f + 0.013f * tipLeft + 0.14f * mainPartLeft); 
            _tipPart.localScale = new Vector3(1, 0.15f + tipLeft * 0.85f, 1);
        }

        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
        }

        public void Move(Vector3 movement)
        {
            _controller.Move(movement);
        }

        private void Update()
        {
            _pencilModel.transform.localRotation = Quaternion.Euler(0, 0, _anglesAim);
            var fadingOnTime = RotationFading *Time.deltaTime;

            if (_anglesAim < -fadingOnTime)
            {
                _anglesAim += fadingOnTime;
            }
            else if (_anglesAim > fadingOnTime)
            {
                _anglesAim -= fadingOnTime;
            }

            _trailRenderer.emitting = _controller.isGrounded;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            switch (hit.gameObject.tag)
            {
                case"Task":
                    var taskSticker = hit.gameObject.GetComponent<ITaskSticker>();
                    TaskFound?.Invoke(taskSticker);
                    break;
            }
        }
    }
}
