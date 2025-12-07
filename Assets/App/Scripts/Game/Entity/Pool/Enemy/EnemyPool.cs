using App.Scripts.Game.Commands.Enemy.OnKill;
using App.Scripts.Game.Entity.Base.Enemy;
using App.Scripts.Game.Entity.Base.Enemy.Config;
using App.Scripts.Game.Entity.Movement.Simple.DirectionProvider.Follow;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Entity.Pool.Enemy
{
    public class EnemyPool : MonoBehaviourPool<EnemyBase>
    {
        private EnemyConfig _enemyConfig;

        private Transform _playerTransform;

        private Timer _timer;

        private ITickableHandler _handler;
        
        public void Construct(EnemyConfig enemyConfig, Transform playerTransform, Timer timer, ITickableHandler handler)
        {
            _enemyConfig = enemyConfig;
            _playerTransform = playerTransform;
            _timer = timer;
            _handler = handler;
            
            CreateStartPool();
        }
        
        protected override EnemyBase Create()
        {
            var obj = Instantiate(prefab, transform);
            
            obj.AttackingEntity.Construct(_enemyConfig.AttackLayerMask, _enemyConfig.Damage);
            obj.DamageableEntity.Construct(_enemyConfig.Health, new EnemyKilledCommand(obj, this, _handler));
            obj.EnemyAnimator.Construct(_enemyConfig.AttackRate, _timer);
            var followTargetDirectionProvider = new FollowTargetDirectionProvider(
                _playerTransform, 
                obj.transform, 
                _enemyConfig.ReachTargetDistance);
            
            obj.MovingEntity.Construct(followTargetDirectionProvider, _enemyConfig.Speed);
            
            UsingObjects.Add(obj);
            ReturnObject(obj);
            return obj;
        }

        public override void ReturnObject(EnemyBase pooledObject)
        {
            pooledObject.EnemyAnimator.Deactivate();
            base.ReturnObject(pooledObject);
        }
    }
}