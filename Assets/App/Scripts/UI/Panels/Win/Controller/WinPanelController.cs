using System;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.UI.Panels.Win.View;

namespace App.Scripts.UI.Panels.Win.Controller
{
    public class WinPanelController : PanelController, IDisposable
    {
        private readonly WinPanelView _view;

        private readonly ICommand _restartCommand;

        public WinPanelController(WinPanelView view, ICommand restartCommand) : base(view)
        {
            _view = view;
            _restartCommand = restartCommand;
            
            InitInput();
        }

        private void InitInput()
        {
            _view.RestartButton.OnClick += _restartCommand.Execute;
        }
        
        public void Dispose()
        {
            _view.RestartButton.OnClick -= _restartCommand.Execute;
        }
    }
}