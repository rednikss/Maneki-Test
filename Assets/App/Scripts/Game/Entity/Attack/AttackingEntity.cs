using App.Scripts.Game.Entity.Attack.Damageable;
using App.Scripts.Libs.Extensions.LayerMask;
using UnityEngine;

namespace App.Scripts.Game.Entity.Attack
{
    public class AttackingEntity : MonoBehaviour
    {
        private float _damageAmount;

        private LayerMask _layerMask;
        
        public void Construct(LayerMask layerMask, float damageAmount)
        {
            _damageAmount = damageAmount;
            _layerMask = layerMask;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent(out IDamageable damageable)) return;
            
            if (!_layerMask.IsLayerInMask(collision.collider.gameObject.layer)) return;
            
            damageable.TakeDamage(_damageAmount);
        }
    }
}