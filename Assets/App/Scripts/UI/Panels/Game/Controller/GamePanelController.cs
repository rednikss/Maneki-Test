using System;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.UI.Panels.Game.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Controller
{
    public class GamePanelController : PanelController, IDisposable
    {
        private readonly GamePanelView _view;

        private readonly ICommand<Vector2> _swipeCommand;
        
        public GamePanelController(GamePanelView view, ICommand<Vector2> swipeCommand) : base(view)
        {
            _view = view;
            _swipeCommand = swipeCommand;
            
            InitInput();
        }

        private void InitInput()
        {
            _view.SwipeZone.OnValueSet += _swipeCommand.Execute;
        }

        public void Dispose()
        {
            _view.SwipeZone.OnValueSet -= _swipeCommand.Execute;
        }
    }
}