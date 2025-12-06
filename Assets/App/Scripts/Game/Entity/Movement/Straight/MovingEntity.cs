using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Straight
{
    public class MovingEntity : MonoBehaviour, ITickable
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private Vector3 _moveDirection;

        private float _moveSpeed;
        
        public void Construct(Vector3 moveDirection, float moveSpeed)
        {
            _moveDirection = moveDirection;
            _moveSpeed = moveSpeed;
            
            transform.forward = moveDirection;
        }
        
        public void Tick(float deltaTime)
        {
            var delta = _moveDirection * deltaTime * _moveSpeed;
            
            _rigidbody.MovePosition(_rigidbody.position + delta);
        }
    }
}