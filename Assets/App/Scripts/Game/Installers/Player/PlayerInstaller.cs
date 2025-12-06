using App.Scripts.Game.Commands.Restart;
using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Entity.Base.Player.Config;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Game.Installers.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        
        [SerializeField] private PlayerBase _playerPrefab;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var position = _playerConfig.StartPosition;
            var player = Instantiate(_playerPrefab, position, Quaternion.identity);
            
            var restartCommand = new RestartGameCommand(_playerConfig, player);
            player.DamageableEntity.Construct(_playerConfig.Health, restartCommand);
            
            player.DashingEntity.Construct(_playerConfig.DashConfig);
            
            player.AttackingEntity.Construct(_playerConfig.Damage);
            
            container.SetServiceSelf(player);
        }
    }
}