using System.Collections.Generic;
using App.Scripts.Game.Entity.Movement.Straight;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Level.Lane.Base
{
    public class LaneBase : MonoBehaviour, ITickable
    {
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private Transform _receivePoint;
        
        private IObjectPool<MovingEntity> _entityPool;

        private List<MovingEntity> _movingEntities;

        public void Construct(IObjectPool<MovingEntity> pool)
        {
            _entityPool = pool;
            _movingEntities = new();
        }
        
        public void Tick(float deltaTime)
        {
            foreach (var entity in _movingEntities)
            {
                entity.Tick(deltaTime);
            }
        }

        public void RemoveEntity(MovingEntity entity)
        {
            _movingEntities.Remove(entity);
            _entityPool.ReturnObject(entity);
        }

        public void AddEntity(float entitySpeed)
        {
            var entity = _entityPool.Get();
            entity.Construct(CalculateMoveDirection(), entitySpeed);
            entity.transform.position = _spawnPoint.position;
            
            _movingEntities.Add(entity);
        }

        private Vector3 CalculateMoveDirection()
        {
            var dir = _receivePoint.position - _spawnPoint.position;
            dir.y = 0;
            
            return dir.normalized;
        }
    }
}