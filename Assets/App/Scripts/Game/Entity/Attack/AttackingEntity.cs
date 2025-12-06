using App.Scripts.Game.Entity.Attack.Damageable;
using UnityEngine;

namespace App.Scripts.Game.Entity.Attack
{
    public class AttackingEntity : MonoBehaviour
    {
        private float _damageAmount;

        public void Construct(float damageAmount)
        {
            _damageAmount = damageAmount;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent(out IDamageable damageable)) return;
            
            damageable.TakeDamage(_damageAmount);
        }
    }
}