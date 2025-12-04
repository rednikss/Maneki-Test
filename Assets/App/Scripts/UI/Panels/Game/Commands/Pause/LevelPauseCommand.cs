using App.Scripts.Libs.Mechanics.Time.TimeHandler;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Panel.Manager;

namespace App.Scripts.UI.Panels.Game.Commands.Pause
{
    public class LevelPauseCommand : ICommand
    {
        private readonly MonoTimerHandler _handler;

        private readonly PanelManager _panelManager;
        
        public LevelPauseCommand(MonoTimerHandler handler, PanelManager panelManager)
        {
            _handler = handler;
            _panelManager = panelManager;
        }
        
        public void Execute()
        {
            _handler.enabled = false;
        }
    }
}