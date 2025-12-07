using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.AnimatedView.Int;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.UI.Elements.Lock
{
    public class Lock : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image _lockImage;
        
        private AnimatedIntView _counterView;

        private int _insertedKeysCount;

        private int _keysToInsert;

        private ICommand _onKeysInsertedCommand;
        
        public Color Color
        {
            get => _lockImage.color;
            set => _lockImage.color = value;
        }

        public void Construct(AnimatedIntView counterView, int keysToInsert, ICommand onKeysInserted)
        {
            _counterView = counterView;
            _keysToInsert = keysToInsert;
            _onKeysInsertedCommand = onKeysInserted;
            
            _insertedKeysCount = 0;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if (!eventData.pointerDrag.TryGetComponent(out Key.Key key)) return;

            if (key.Color != Color) return;

            _counterView.SetValue(++_insertedKeysCount);
            
            if (_insertedKeysCount == _keysToInsert) _onKeysInsertedCommand.Execute();
        }
    }
}