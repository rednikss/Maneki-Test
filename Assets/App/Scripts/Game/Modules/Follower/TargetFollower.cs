using App.Scripts.Game.Modules.Follower.Config;
using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Game.Modules.Follower
{
    public class TargetFollower : ITickable
    {
        private readonly FollowConfig _config;
        
        private readonly Transform _target;

        private readonly Transform _follower;

        public TargetFollower(FollowConfig config, Transform target, Transform follower)
        {
            _target = target;
            _follower = follower;
            _config = config;

            var position = _target.position;
            _follower.position = position + _config.FollowerDistance;
            _follower.LookAt(position + _config.TargetLookPointDelta);
        }
        
        public void Tick(float deltaTime)
        {
            var newPosition = _target.position + _config.FollowerDistance;

            _follower.position = Vector3.Lerp(_follower.position, newPosition, deltaTime * _config.FollowSpeed);
        }
    }
}