using App.Scripts.Game.Entity.Attack;
using App.Scripts.Game.Entity.Attack.Damageable;
using App.Scripts.Game.Entity.Movement.Simple;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private MovingEntity _movingEntity;

        [SerializeField] private AttackingEntity _attackingEntity;

        [SerializeField] private DamageableEntity _damageableEntity;

        public MovingEntity MovingEntity => _movingEntity;

        public AttackingEntity AttackingEntity => _attackingEntity;

        public DamageableEntity DamageableEntity => _damageableEntity;
    }
}