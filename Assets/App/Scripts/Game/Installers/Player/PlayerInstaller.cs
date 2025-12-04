using App.Scripts.Game.Player.Base;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Game.Installers.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBase _playerPrefab;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var position = new Vector3(0, 0.375f, 0);
            
            var player = Instantiate(_playerPrefab, position, Quaternion.identity);

            container.SetServiceSelf(player);
        }
    }
}