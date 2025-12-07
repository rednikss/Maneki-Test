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

        public override void InstallBindings(ServiceContainer container)
        {
            var player = container.GetService<PlayerBase>();

            player.DashingEntity.Construct(_playerConfig.DashConfig);
            
            player.AttackingEntity.Construct(_playerConfig.AttackLayerMask, _playerConfig.Damage);
            
            container.SetServiceSelf(player);
        }
    }
}