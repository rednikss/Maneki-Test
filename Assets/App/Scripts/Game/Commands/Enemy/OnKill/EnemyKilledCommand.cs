using App.Scripts.Game.Entity.Base.Enemy;
using App.Scripts.Game.Entity.Pool.Enemy;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Patterns.Command.Default;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Commands.Enemy.OnKill
{
    public class EnemyKilledCommand : ICommand
    {
        private readonly EnemyBase _enemyBase;

        private readonly EnemyPool _enemyPool;
        
        private readonly ITickableHandler _handler;

        public EnemyKilledCommand(EnemyBase enemyBase, EnemyPool enemyPool, ITickableHandler handler)
        {
            _enemyBase = enemyBase;
            _enemyPool = enemyPool;
            _handler = handler;
        }
        
        public async void Execute()
        {
            await _enemyBase.transform.DOScale(Vector3.zero, 0.5f)
                .SetEase(Ease.OutCubic)
                .SetLink(_enemyBase.gameObject)
                .ToUniTask();
            
            _handler.RemoveTickable(_enemyBase);
            _enemyPool.ReturnObject(_enemyBase);
            _enemyBase.transform.localScale = Vector3.one;
        }
    }
}