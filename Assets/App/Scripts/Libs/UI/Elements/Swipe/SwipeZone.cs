using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.Libs.UI.Elements.Swipe
{
    public class SwipeZone : Selectable, IDragHandler ////min length
    {
        public event Action<Vector2> OnValueSet;
        
        private Vector2 _value;

        private Vector2 _swipeStartPoint;

        private Camera _activeCamera;

        public void Construct(Camera activeCamera)
        {
            _activeCamera = activeCamera;
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            _swipeStartPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _value = CalculateValue(_swipeStartPoint, eventData.position);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            OnValueSet?.Invoke(_value);
            _value = Vector2.zero;
        }

        public Vector2 GetValue() => _value;

        private Vector2 CalculateValue(Vector2 pixelStartPosition, Vector2 pixelEndPosition)
        {
            var posDelta = pixelStartPosition - pixelEndPosition;
            posDelta *= _activeCamera.orthographicSize * 2 / _activeCamera.pixelHeight;
            
            return posDelta;
        }
    }
}