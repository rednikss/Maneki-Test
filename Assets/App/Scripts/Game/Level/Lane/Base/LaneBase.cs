using System.Collections.Generic;
using App.Scripts.Game.Entity.Movement.DirectionProvider.Straight;
using App.Scripts.Game.Entity.Obstacle.Base;
using App.Scripts.Libs.Mechanics.Time.Tickable;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Level.Lane.Base
{
    public class LaneBase : MonoBehaviour, ITickable
    {
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private Transform _receivePoint;
        
        private IObjectPool<ObstacleBase> _entityPool;

        private List<ObstacleBase> _movingEntities;

        public void Construct(IObjectPool<ObstacleBase> pool)
        {
            _entityPool = pool;
            _movingEntities = new();
        }
        
        public void Tick(float deltaTime)
        {
            foreach (var entity in _movingEntities)
            {
                entity.MovingEntity.Tick(deltaTime);
            }
        }

        public void RemoveEntity(ObstacleBase entity)
        {
            _movingEntities.Remove(entity);
            _entityPool.ReturnObject(entity);
        }

        public void AddEntity(float entitySpeed)
        {
            var entity = _entityPool.Get();
            var startPosition = _spawnPoint.position;
            var provider = new StraightDirectionProvider(_receivePoint.transform.position - startPosition);
            
            entity.MovingEntity.Construct(provider, entitySpeed);
            entity.ObstacleAnimator.SetSpeed(entitySpeed);
            entity.transform.position = startPosition;
            
            _movingEntities.Add(entity);
        }
    }
}