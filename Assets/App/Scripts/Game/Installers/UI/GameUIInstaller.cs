using System.Collections.Generic;
using App.Scripts.Game.Commands.Restart;
using App.Scripts.Game.Commands.Swipe;
using App.Scripts.Game.Commands.Win;
using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Installers.Level;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Elements.Key;
using App.Scripts.UI.Panels.Chest.Config;
using App.Scripts.UI.Panels.Chest.Factory;
using App.Scripts.UI.Panels.Chest.View;
using App.Scripts.UI.Panels.Game.Factory;
using App.Scripts.UI.Panels.Game.View;
using App.Scripts.UI.Panels.Win.Factory;
using App.Scripts.UI.Panels.Win.View;
using UnityEngine;

namespace App.Scripts.Game.Installers.UI
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private GamePanelView _levelPanelView;

        [SerializeField] private ChestPanelConfig _chestPanelConfig;
        
        [SerializeField] private ChestPanelView _chestPanelView;

        [SerializeField] private Key _keyPrefab;

        [SerializeField] private WinPanelView _winPanelView;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var panelManager = container.GetService<PanelManager>();
            
            var factoryList = new List<IFactory<PanelController>>
            {
                BuildGamePanelFactory(container),
                BuildChestPanelFactory(container),
                BuildWinPanelFactory(container)
            };

            panelManager.SetFactories(factoryList);
        }

        private WinPanelFactory BuildWinPanelFactory(ServiceContainer container)
        {
            return new WinPanelFactory(_winPanelView,
                container.GetService<Canvas>(),
                container.GetService<DelayedCommandProvider<RestartGameCommand>>());
        }

        private ChestPanelFactory BuildChestPanelFactory(ServiceContainer container)
        {
            var winCommand = new WinGameCommand(container.GetService<PanelManager>());
            
            return new ChestPanelFactory(container.GetService<Canvas>(), 
                _chestPanelConfig, _chestPanelView,  _keyPrefab, winCommand);
        }

        private GamePanelFactory BuildGamePanelFactory(ServiceContainer container)
        {
            var swipe = new PlayerSwipeCommand(
                container.GetService<PlayerBase>().DashingEntity);
            
            return new GamePanelFactory(_levelPanelView, 
                container.GetService<Canvas>(), swipe);
        }
    }
}