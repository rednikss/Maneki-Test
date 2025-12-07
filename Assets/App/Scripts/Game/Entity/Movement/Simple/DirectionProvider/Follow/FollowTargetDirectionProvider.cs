using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Simple.DirectionProvider.Follow
{
    public class FollowTargetDirectionProvider : IDirectionProvider
    {
        private readonly Transform _target;

        private readonly Transform _source;

        private readonly float _reachDistance;

        public FollowTargetDirectionProvider(Transform target, Transform source, float reachDistance)
        {
            _target = target;
            _source = source;
            _reachDistance = reachDistance;
        }
        
        public Vector3 GetDirection()
        {
            var dir = 
                _target.position - 
                      _source.position;
            dir.y = 0;
            
            return (dir.sqrMagnitude < _reachDistance * _reachDistance) ? Vector3.zero : dir.normalized;
        }
    }
}