using App.Scripts.Game.Entity.Attack;
using App.Scripts.Game.Entity.Attack.Damageable;
using App.Scripts.Game.Entity.Base.Enemy.Animation;
using App.Scripts.Game.Entity.Movement.Simple;
using App.Scripts.Libs.Mechanics.Time.Tickable;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Enemy
{
    public class EnemyBase : MonoBehaviour, ITickable
    {
        [SerializeField] private MovingEntity _movingEntity;

        [SerializeField] private AttackingEntity _attackingEntity;

        [SerializeField] private DamageableEntity _damageableEntity;

        [SerializeField] private EnemyAnimator _enemyAnimator;

        public MovingEntity MovingEntity => _movingEntity;

        public AttackingEntity AttackingEntity => _attackingEntity;

        public DamageableEntity DamageableEntity => _damageableEntity;
        
        public EnemyAnimator EnemyAnimator => _enemyAnimator;
        
        public void Tick(float deltaTime)
        {
            _movingEntity.Tick(deltaTime);
        }
    }
}