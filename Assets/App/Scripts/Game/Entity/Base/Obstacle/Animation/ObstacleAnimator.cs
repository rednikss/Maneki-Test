using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Obstacle.Animation
{
    public class ObstacleAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private string _animationName;
        
        private int _animationHash;

        public void Construct()
        {
            _animationHash = Animator.StringToHash(_animationName);
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(_animationHash, speed);
        }
    }
    
}