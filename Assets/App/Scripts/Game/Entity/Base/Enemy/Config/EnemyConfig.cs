using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Enemy.Config
{
    [CreateAssetMenu(fileName = "Default Enemy Config", menuName = "Scriptable Object/Game/Enemy Config", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public float Health;

        public float Speed;
        
        public float ReachTargetDistance;
        
        public float Damage;

        public LayerMask AttackLayerMask;

        public float AttackRate;
    }
}