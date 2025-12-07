using System.Collections.Generic;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.UI.Elements.Key;
using App.Scripts.UI.Panels.Chest.Config;
using App.Scripts.UI.Panels.Chest.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Chest.Controller
{
    public class ChestPanelController : PanelController
    {
        private readonly Canvas _canvas;
        
        private readonly ChestPanelConfig _config;

        private readonly ChestPanelView _view;

        private readonly Key _keyPrefab;
        
        private readonly ICommand _onChestUnlockedCommand;

        private readonly List<Key> _keys;
        
        public ChestPanelController(Canvas canvas, ChestPanelConfig config, ChestPanelView view, Key keyPrefab, 
            ICommand onChestUnlockedCommand) : base(view)
        {
            _canvas = canvas;
            _config = config;
            _view = view;
            _keyPrefab = keyPrefab;
            _onChestUnlockedCommand = onChestUnlockedCommand;
            _keys = new List<Key>();
            
            ResetPanel();
            
            GenerateKeys();
        }

        public void ResetPanel()
        {
            _view.CounterView.Construct("", $"/{_config.KeysToOpen}");
            _view.Lock.Construct(_view.CounterView, _config.KeysToOpen, _onChestUnlockedCommand);
        }
        
        public void SetColor(Color lockColor)
        {
            _view.Lock.Color = lockColor;

            for (int i = 0; i < _config.KeysToOpen; i++)
            {
                var key = _keys[i];
                
                key.Color = lockColor;
                key.transform.SetSiblingIndex(Random.Range(0, _keys.Count));
            }
        }

        private void GenerateKeys()
        {
            for (int i = 0; i < _config.KeyCount; i++)
            {
                var key = Object.Instantiate(_keyPrefab, _view.KeyPanel);
                key.Construct(_canvas);
                _keys.Add(key);

                var newColor = _config.KeyColors[Random.Range(0, _config.KeyColors.Length)];
                key.Color = newColor;
            }
        }
    }
}