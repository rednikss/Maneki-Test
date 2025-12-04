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

        private readonly ICommand _pauseCommand;
        
        private readonly ICommand<Vector2> _swipeCommand;
        
        public GamePanelController(GamePanelView view, ICommand pauseCommand, ICommand<Vector2> swipeCommand) : base(view)
        {
            _view = view;
            _pauseCommand = pauseCommand;
            _swipeCommand = swipeCommand;
            
            InitInput();
        }

        private void InitInput()
        {
            _view.PauseButton.OnClick += _pauseCommand.Execute;
            _view.SwipeZone.OnValueSet += _swipeCommand.Execute;
        }
        
        public void SetInputInteractable(bool value)
        {
            _view.SwipeZone.enabled = value;
        }

        public Vector2 GetCurrentSwipe() => _view.SwipeZone.GetValue();

        public void Dispose()
        {
            _view.PauseButton.OnClick -= _pauseCommand.Execute;
            _view.SwipeZone.OnValueSet -= _swipeCommand.Execute;
        }
    }
}