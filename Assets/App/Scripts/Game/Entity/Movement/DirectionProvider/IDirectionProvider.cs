using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.DirectionProvider
{
    public interface IDirectionProvider
    {
        public Vector3 GetDirection();
    }
}