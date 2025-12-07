using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Obstacle.Config
{
    [CreateAssetMenu(fileName = "Default Obstacle Config", menuName = "Scriptable Object/Game/Obstacle Config", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        public float Damage;
        
        public LayerMask AttackLayerMask;
    }
}