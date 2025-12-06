using App.Scripts.Game.Entity.Movement.DirectionProvider;
using App.Scripts.Libs.Mechanics.Time.Timer;
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
            var delta = deltaTime * _moveSpeed * direction;

            _rigidbody.MovePosition(_rigidbody.position + delta);
        }
    }
}