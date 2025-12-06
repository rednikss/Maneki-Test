using UnityEngine;

namespace App.Scripts.Game.Entity.Obstacle.Base.Config
{
    [CreateAssetMenu(fileName = "Default Obstacle Config", menuName = "Scriptable Object/Game/Obstacle Config", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        public float Damage;
    }
}