using System.Collections.Generic;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Game.Controller;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : MonoInitializable
    {
        private PanelManager _panelManager;

        private IEnumerable<LaneHandler> _laneHandlers;
        
        public void Construct(PanelManager panelManager, IEnumerable<LaneHandler> laneHandlers)
        {
            _panelManager = panelManager;
            _laneHandlers = laneHandlers;
        }

        public override async void Init()
        {
            var panel = _panelManager.GetPanel<GamePanelController>();

            foreach (var laneHandler in _laneHandlers)
            {
                laneHandler.Start();
            }
            
            await panel.ShowAnimated();
        }
    }
}