using App.Scripts.Game.Level.Config;
using App.Scripts.Game.Player.Base;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Game.Installers.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _Config;
        
        public override void InstallBindings(ServiceContainer container)
        {
            container.GetService<PlayerBase>().transform.position = _Config.StartPlayerPosition;
            
        }
    }
}