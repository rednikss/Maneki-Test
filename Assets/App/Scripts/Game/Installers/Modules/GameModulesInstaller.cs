using App.Scripts.Game.Modules.Follower;
using App.Scripts.Game.Modules.Follower.Config;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Game.Player.Base;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.TimeHandler;
using App.Scripts.Libs.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Game.Installers.Modules
{
    public class GameModulesInstaller : MonoInstaller
    {
        [SerializeField] private FollowConfig _playerFollowConfig;
        
        [SerializeField] private Transform _cameraTransform;

        [SerializeField] private GameSceneStarter _sceneStarter;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var follower = new TargetFollower(_playerFollowConfig, 
                container.GetService<PlayerBase>().transform, 
                _cameraTransform);
            
            container.GetService<MonoTimerHandler>().AddTickable(follower);
            
            _sceneStarter.Construct(container.GetService<PanelManager>());
        }
    }
}