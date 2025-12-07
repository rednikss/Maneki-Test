using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.UI.Elements.Key
{
    public class Key : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _image;
        
        [SerializeField] private RectTransform _rectTransform;

        private Canvas _canvas;
        
        private Transform _previousParent;
        
        private Vector3 _previousPosition;
        
        public Color Color
        {
            get => _image.color;
            set => _image.color = value;
        }

        public void Construct(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            var keyTransform = transform;
            _previousParent = keyTransform.parent;
            _previousPosition = keyTransform.position;
                
            keyTransform.SetParent(_previousParent.parent);
            _image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _image.raycastTarget = true;

            var keyTransform = transform;
            keyTransform.SetParent(_previousParent);
            keyTransform.position = _previousPosition;
        }
    }
}