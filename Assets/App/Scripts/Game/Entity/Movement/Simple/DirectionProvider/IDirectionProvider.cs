using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Simple.DirectionProvider
{
    public interface IDirectionProvider
    {
        public Vector3 GetDirection();
    }
}