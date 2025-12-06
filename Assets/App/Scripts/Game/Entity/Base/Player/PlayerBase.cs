using App.Scripts.Game.Entity.Attack;
using App.Scripts.Game.Entity.Attack.Damageable;
using App.Scripts.Game.Entity.Movement.Dash;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Player
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] private DashingEntity _dashingEntity;

        [SerializeField] private AttackingEntity _attackingEntity;

        [SerializeField] private DamageableEntity _damageableEntity;
        
        public DashingEntity DashingEntity => _dashingEntity;

        public AttackingEntity AttackingEntity => _attackingEntity;

        public DamageableEntity DamageableEntity => _damageableEntity;
    }
}