using System.Collections.Generic;
using App.Scripts.Game.Entity.Base.Enemy;
using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Entity.Pool.Enemy;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Game.Modules.Starter;
using App.Scripts.Libs.Mechanics.Time.Tickable.Container;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Commands.Restart
{
    public class RestartGameCommand : ICommand
    {
        private readonly IEnumerable<LaneHandler> _handlers;
        
        private readonly ITickableHandler _enemiesTickable;
        private readonly TickableContainer<EnemyBase> _enemies;
        private readonly EnemyPool _enemyPool;
        
        private readonly PlayerBase _player;
        private readonly GameSceneStarter _starter;
        
        public RestartGameCommand(
            IEnumerable<LaneHandler> handlers, 
            ITickableHandler enemiesTickable,
            TickableContainer<EnemyBase> enemies,
            EnemyPool enemyPool,
            PlayerBase player, GameSceneStarter starter)
        {
            _handlers = handlers;
            _enemiesTickable = enemiesTickable;
            _enemies = enemies;
            _enemyPool = enemyPool;
            _player = player;
            _starter = starter;
        }
        
        public void Execute()
        {
            foreach (var handler in _handlers) handler.Deactivate();

            foreach (var enemyBase in _enemies)
            {
                _enemyPool.ReturnObject(enemyBase);
                _enemiesTickable.RemoveTickable(enemyBase);
            }
            
            _player.DamageableEntity.ResetHealth();
            
            _starter.Init();
        }
    }
}