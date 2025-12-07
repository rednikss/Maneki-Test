using App.Scripts.Game.Entity.Movement.Simple.DirectionProvider;
using App.Scripts.Libs.Mechanics.Time.Tickable;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Simple
{
    public class MovingEntity : MonoBehaviour, ITickable
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private IDirectionProvider _directionProvider;

        private float _moveSpeed;

        public void Construct(IDirectionProvider directionProvider, float moveSpeed)
        {
            _directionProvider = directionProvider;
            _moveSpeed = moveSpeed;
        }
        
        public void Tick(float deltaTime)
        {
            var direction = _directionProvider.GetDirection();
            
            if (direction == Vector3.zero) return;
            
            var delta = deltaTime * _moveSpeed * direction;
            
            _rigidbody.Move(_rigidbody.position + delta, 
                Quaternion.LookRotation(direction));
        }
    }
}