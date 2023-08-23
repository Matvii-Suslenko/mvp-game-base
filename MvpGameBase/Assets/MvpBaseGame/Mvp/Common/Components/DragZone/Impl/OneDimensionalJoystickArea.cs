using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace MvpBaseGame.Mvp.Common.Components.DragZone.Impl
{
    public class OneDimensionalJoystickArea : MonoBehaviour, IOneDimensionalJoystickArea, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        private const float DragValueMultiplier = 1000f;
        private const float IndicatorStepOffset = 100f;
            
        public event Action<float> Drag;
        
        [SerializeField]
        private RectTransform[] _joystickInputIndicators;
        
        [SerializeField]
        private RectTransform _area;
        
        [SerializeField]
        private RectTransform _aim;
        
        [SerializeField]
        private Axis _axis;

        private Vector2 _startPointerPosition;
        private Vector2 _lastPointerPosition;
        private Vector2 _baseVector;
        private Camera _camera;
        private bool _isDrag;
        
        private readonly float _maxOffset = Screen.width / 4f;

        private void Start()
        {
            _camera = Camera.main;
            _aim.gameObject.SetActive(false);
            _baseVector = _axis == Axis.Horizontal ? Vector2.right : Vector2.up;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_area, eventData.pressPosition, _camera, out var localPoint);
            _aim.anchoredPosition = localPoint;
            _aim.gameObject.SetActive(true);
            
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

            var dragValue = input > 0 ? 
                input > _maxOffset ? 1 : input / _maxOffset : 
                input < -_maxOffset ? -1 : input / _maxOffset;

            Drag?.Invoke(dragValue * Time.deltaTime * DragValueMultiplier);
            
            for (var i = 0; i < _joystickInputIndicators.Length; i++)
            {
                _joystickInputIndicators[i].localPosition = _baseVector * (dragValue * (i+1) * IndicatorStepOffset);
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
            _aim.gameObject.SetActive(false);
            _isDrag = false;
        }
    }
}
