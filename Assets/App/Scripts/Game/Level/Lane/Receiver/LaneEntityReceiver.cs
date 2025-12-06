using App.Scripts.Game.Entity.Obstacle.Base;
using App.Scripts.Game.Level.Lane.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Lane.Receiver
{
    public class LaneEntityReceiver : MonoBehaviour
    {
        [SerializeField] private LaneBase _laneBase;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ObstacleBase entity)) return;

            _laneBase.RemoveEntity(entity);
        }
    }
}