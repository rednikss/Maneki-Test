using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.UI.Panels.Win.Controller;
using App.Scripts.UI.Panels.Win.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Win.Factory
{
    public class WinPanelFactory : IFactory<WinPanelController>
    {
        private readonly Canvas _canvas;

        private readonly WinPanelView _viewPrefab;

        private readonly ICommand _restartCommand;
        
        public WinPanelFactory(WinPanelView view, Canvas canvas, ICommand restartCommand)
        {
            _canvas = canvas;
            _viewPrefab = view;
            _restartCommand = restartCommand;
        }
        
        public WinPanelController Create()
        {
            var panelView = Object.Instantiate(_viewPrefab, _canvas.transform);
            panelView.Hide();
            
            var panelController = new WinPanelController(panelView, _restartCommand);
            
            return panelController;
        }
    }
}