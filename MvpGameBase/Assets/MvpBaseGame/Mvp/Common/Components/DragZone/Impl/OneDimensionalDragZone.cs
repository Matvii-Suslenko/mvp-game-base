using System;
using UnityEngine.EventSystems;
using UnityEngine;

namespace MvpBaseGame.Mvp.Common.Components.DragZone.Impl
{
    public class OneDimensionalDragZone : MonoBehaviour, IOneDimensionalDragZone, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        public event Action<float> Drag;
        
        [SerializeField]
        private Axis _axis;
        
        private Vector2? _prevPosition;
        private bool _isDrag;

        public void OnPointerDown(PointerEventData eventData)
        {
            _isDrag = true;
            _prevPosition = eventData.pressPosition;
        }
        
        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_isDrag)
            {
                return;
            }

            if (_prevPosition != null)
            {
                var drag = _prevPosition.Value - eventData.position;
                Drag?.Invoke(_axis == Axis.Horizontal ? drag.x : drag.y);
            }
            
            _prevPosition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isDrag = false;
            _prevPosition = null;
        }
    }
}
