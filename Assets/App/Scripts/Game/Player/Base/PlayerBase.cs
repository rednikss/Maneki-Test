using App.Scripts.Game.Entity.Movement.Dash;
using UnityEngine;

namespace App.Scripts.Game.Player.Base
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] private DashingEntity _dashingEntity;

        public DashingEntity Movement => _dashingEntity;

    }
}