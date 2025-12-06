using App.Scripts.Game.Entity.Movement.Dash.Config;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Player.Config
{
    [CreateAssetMenu(fileName = "Default Player Config", menuName = "Scriptable Object/Game/Player Config", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public Vector3 StartPosition;

        public float Health;
        
        public float Damage;

        public DashConfig DashConfig;
    }
}