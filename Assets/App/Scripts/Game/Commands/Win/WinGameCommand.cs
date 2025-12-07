using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Chest.Controller;
using App.Scripts.UI.Panels.Win.Controller;

namespace App.Scripts.Game.Commands.Win
{
    public class WinGameCommand : ICommand
    {
        private readonly PanelManager _panelManager;

        public WinGameCommand(PanelManager panelManager)
        {
            _panelManager = panelManager;
        }
        
        public async void Execute()
        {
            await _panelManager.GetPanel<ChestPanelController>().HideAnimated();
            
            var panel = _panelManager.GetPanel<WinPanelController>();
            
            await panel.ShowAnimated();
        }
    }
}