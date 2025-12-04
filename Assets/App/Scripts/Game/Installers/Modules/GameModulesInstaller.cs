using App.Scripts.Game.Starter;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Game.Installers.Modules
{
    public class GameModulesInstaller : MonoInstaller
    {
        [SerializeField] private GameSceneStarter _sceneStarter;
        
        public override void InstallBindings(ServiceContainer container)
        {
            _sceneStarter.Construct(container.GetService<PanelManager>());
        }
    }
}