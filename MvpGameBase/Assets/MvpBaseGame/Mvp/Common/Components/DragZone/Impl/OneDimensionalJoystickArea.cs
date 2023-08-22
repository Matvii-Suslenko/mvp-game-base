using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Components.DragZone.Impl
{
    public class OneDimensionalJoystickArea : MonoBehaviour, IOneDimensionalJoystickArea, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        public event Action<float> Drag;
        
        
        [SerializeField]
        private Axis _axis;

        private Vector2 _startPointerPosition;
        private Vector2 _lastPointerPosition;
        private bool _isDrag;
        
        private readonly float _maxOffset = Screen.width / 4f;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPointerPosition = eventData.pressPosition;
            _lastPointerPosition = _startPointerPosition;
            _isDrag = true;
        }

        private void Update()
        {
            if (!_isDrag)
            {
                return;
            }

            var inputVector = _lastPointerPosition - _startPointerPosition;
            var input = _axis == Axis.Horizontal ? inputVector.x : inputVector.y;
            input *= Time.deltaTime * 1000f;

            if (input > 0)
            {
                Drag?.Invoke(input > _maxOffset ? 1 : input / _maxOffset);
            }
            else
            {
                Drag?.Invoke(input < -_maxOffset ? -1 : input / _maxOffset);
            }
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_isDrag)
            {
                return;
            }

            _lastPointerPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDrag = false;
        }
    }
}
