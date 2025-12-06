using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Game.Modules.Follower;
using App.Scripts.Game.Modules.Follower.Config;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Tickable.Container;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Default;
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
            
            container.GetService<MonoTickableHandler>().AddTickable(follower);
            
            _sceneStarter.Construct(container.GetService<PanelManager>(), 
                container.GetService<TickableContainer<LaneHandler>>());
        }
    }
}