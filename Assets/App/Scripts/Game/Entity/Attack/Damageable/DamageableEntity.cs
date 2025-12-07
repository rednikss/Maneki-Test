using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Game.Entity.Attack.Damageable
{
    public class DamageableEntity : MonoBehaviour, IDamageable
    {
        private ICommand _onKillCommand;

        private float _maxHealth;
        private float _health;

        public void Construct(float health, ICommand onKillCommand)
        {
            _maxHealth = _health = health;
            _onKillCommand = onKillCommand;
        }
        
        public void TakeDamage(float damage)
        {
            if (_health <= 0) return;
            _health -= damage;
            
            if (_health > 0) return;
            _onKillCommand.Execute();
        }

        public void ResetHealth()
        {
            _health = _maxHealth;
        }
    }
}