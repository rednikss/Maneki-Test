using App.Scripts.Game.Entity.Attack;
using App.Scripts.Game.Entity.Movement.Simple;
using App.Scripts.Game.Entity.Obstacle.Animation;
using UnityEngine;

namespace App.Scripts.Game.Entity.Obstacle.Base
{
    public class ObstacleBase : MonoBehaviour
    {
        [SerializeField] private MovingEntity _movingEntity;

        [SerializeField] private AttackingEntity _attackingEntity;

        [SerializeField] private ObstacleAnimator _obstacleAnimator;

        public MovingEntity MovingEntity => _movingEntity;

        public AttackingEntity AttackingEntity => _attackingEntity;
        
        public ObstacleAnimator ObstacleAnimator => _obstacleAnimator;
    }
}