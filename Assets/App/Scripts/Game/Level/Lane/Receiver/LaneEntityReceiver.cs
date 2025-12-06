using App.Scripts.Game.Entity.Movement.Straight;
using App.Scripts.Game.Level.Lane.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Lane.Receiver
{
    public class LaneEntityReceiver : MonoBehaviour
    {
        [SerializeField] private LaneBase _laneBase;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out MovingEntity entity)) return;

            _laneBase.RemoveEntity(entity);
        }
    }
}