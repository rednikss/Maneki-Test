using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.UI.Panels.Game.Controller;
using App.Scripts.UI.Panels.Game.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Factory
{
    public class GamePanelFactory : IFactory<GamePanelController>
    {
        private readonly Canvas _canvas;

        private readonly GamePanelView _viewPrefab;

        private readonly ICommand _pauseCommand;
        
        private readonly ICommand<Vector2> _swipeCommand;
        
        public GamePanelFactory(GamePanelView view, Canvas canvas, ICommand pauseCommand, ICommand<Vector2> swipeCommand)
        {
            _canvas = canvas;
            _viewPrefab = view;
            _pauseCommand = pauseCommand;
            _swipeCommand = swipeCommand;
        }
        
        public GamePanelController Create()
        {
            var panelView = Object.Instantiate(_viewPrefab, _canvas.transform);
            panelView.SwipeZone.Construct(_canvas.worldCamera, 0.5f);
            panelView.Hide();
            
            var panelController = new GamePanelController(panelView, _pauseCommand, _swipeCommand);
            
            return panelController;
        }
    }
}