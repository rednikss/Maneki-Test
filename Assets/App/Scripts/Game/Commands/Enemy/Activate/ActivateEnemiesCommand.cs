using System.Collections.Generic;
using App.Scripts.Game.Entity.Base.Enemy;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Commands.Enemy.Activate
{
    public class ActivateEnemiesCommand : ICommand
    {
        private readonly ITickableHandler _handler;

        private readonly IEnumerable<EnemyBase> _enemyBases;

        public ActivateEnemiesCommand(ITickableHandler handler, IEnumerable<EnemyBase> enemyBases)
        {
            _handler = handler;
            _enemyBases = enemyBases;
        }
        
        public void Execute()
        {
            foreach (var enemyBase in _enemyBases)
            {
                _handler.AddTickable(enemyBase);
                enemyBase.EnemyAnimator.Activate();
            }
        }
    }
}