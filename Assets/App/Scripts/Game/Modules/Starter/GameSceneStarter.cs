using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Game.Controller;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : MonoInitializable
    {
        private PanelManager _panelManager;
        
        public void Construct(PanelManager panelManager)
        {
            _panelManager = panelManager;
        }
        
        public override async void Init()
        {
            var panel = _panelManager.GetPanel<GamePanelController>();
            await panel.ShowAnimated();
        }
    }
}