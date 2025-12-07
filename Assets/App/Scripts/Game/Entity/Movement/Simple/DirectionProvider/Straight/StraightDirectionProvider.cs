using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Simple.DirectionProvider.Straight
{
    public class StraightDirectionProvider : IDirectionProvider
    {
        private readonly Vector3 _direction;

        public StraightDirectionProvider(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        public Vector3 GetDirection() => _direction;
    }
}