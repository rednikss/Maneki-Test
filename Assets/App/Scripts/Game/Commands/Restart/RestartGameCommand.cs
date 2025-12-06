using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Entity.Base.Player.Config;
using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Commands.Restart
{
    public class RestartGameCommand : ICommand
    {
        private readonly PlayerConfig _playerConfig;
        
        private readonly PlayerBase _player;
        
        public RestartGameCommand(PlayerConfig playerConfig, PlayerBase player)
        {
            _playerConfig = playerConfig;
            _player = player;
        }
        
        public void Execute()
        {
            _player.transform.position = _playerConfig.StartPosition;
            _player.DamageableEntity.Construct(_playerConfig.Health, this);
        }
    }
}