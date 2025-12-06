using App.Scripts.Game.Entity.Attack;
using App.Scripts.Game.Entity.Movement.Simple;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Obstacle
{
    public class ObstacleBase : MonoBehaviour
    {
        [SerializeField] private MovingEntity _movingEntity;

        [SerializeField] private AttackingEntity _attackingEntity;

        public MovingEntity MovingEntity => _movingEntity;

        public AttackingEntity AttackingEntity => _attackingEntity;
    }
}