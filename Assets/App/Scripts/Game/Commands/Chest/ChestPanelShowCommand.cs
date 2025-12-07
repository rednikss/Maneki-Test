using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Chest.Config;
using App.Scripts.UI.Panels.Chest.Controller;
using UnityEngine;

namespace App.Scripts.Game.Commands.Chest
{
    public class ChestPanelShowCommand : ICommand
    {
        private readonly PanelManager _panelManager;
        
        private readonly ChestPanelConfig _config;

        public ChestPanelShowCommand(PanelManager panelManager, ChestPanelConfig config)
        {
            _panelManager = panelManager;
            _config = config;
        }

        public void Execute()
        {
            var panel = _panelManager.GetPanel<ChestPanelController>();
            panel.SetColor(_config.KeyColors[Random.Range(0, _config.KeyColors.Length)]);
            panel.ResetPanel();
            panel.Show();
        }
    }
}