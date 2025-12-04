using System.Collections.Generic;
using App.Scripts.Game.Player.Base;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.TimeHandler;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Game.Commands.Pause;
using App.Scripts.UI.Panels.Game.Commands.Swipe;
using App.Scripts.UI.Panels.Game.Factory;
using App.Scripts.UI.Panels.Game.View;
using UnityEngine;

namespace App.Scripts.Game.Installers.UI
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private GamePanelView _levelPanelView;

        public override void InstallBindings(ServiceContainer container)
        {
            var panelManager = container.GetService<PanelManager>();
            
            var factoryList = new List<IFactory<PanelController>>
            {
                BuildGamePanelFactory(container)
            };

            panelManager.SetFactories(factoryList);
        }

        private GamePanelFactory BuildGamePanelFactory(ServiceContainer container)
        {
            var manager = container.GetService<PanelManager>();
            
            var pause = new LevelPauseCommand(
                container.GetService<MonoTimerHandler>(),
                manager);

            var swipe = new PlayerSwipeCommand(
                container.GetService<PlayerBase>().Movement);
            
            return new GamePanelFactory(_levelPanelView, 
                container.GetService<Canvas>(),
                pause, swipe);
        }
    }
}