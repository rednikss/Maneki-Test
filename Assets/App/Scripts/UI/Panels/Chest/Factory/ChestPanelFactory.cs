using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.UI.Elements.Key;
using App.Scripts.UI.Panels.Chest.Config;
using App.Scripts.UI.Panels.Chest.Controller;
using App.Scripts.UI.Panels.Chest.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Chest.Factory
{
    public class ChestPanelFactory : IFactory<ChestPanelController>
    {
        private readonly Canvas _canvas;
        
        private readonly ChestPanelConfig _config;
        
        private readonly ChestPanelView _view;
        
        private readonly Key _keyPrefab;

        private readonly ICommand _chestUnlockCommand;

        public ChestPanelFactory(Canvas canvas, ChestPanelConfig config, ChestPanelView view, Key keyPrefab, ICommand chestUnlockCommand)
        {
            _canvas = canvas;
            _config = config;
            _view = view;
            _keyPrefab = keyPrefab;
            _chestUnlockCommand = chestUnlockCommand;
        }

        public ChestPanelController Create()
        {
            var panelView = Object.Instantiate(_view, _canvas.transform);
            panelView.Hide();
            
            return new ChestPanelController(_canvas, _config, panelView, _keyPrefab, _chestUnlockCommand);
        }
    }
}