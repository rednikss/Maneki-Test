using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.DirectionProvider.Follow
{
    public class FollowTargetDirectionProvider : IDirectionProvider
    {
        private readonly Transform _target;

        private readonly Transform _source;

        public FollowTargetDirectionProvider(Transform target, Transform source)
        {
            _target = target;
            _source = source;
        }
        
        public Vector3 GetDirection()
        {
            var dir = _target.position - _source.position;
            dir.y = 0;

            return dir.normalized;
        }
    }
}