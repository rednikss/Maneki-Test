using UnityEngine;

namespace App.Scripts.Game.Level.Lane.Base.Config
{
    [CreateAssetMenu(fileName = "Default Lane Config", menuName = "Scriptable Object/Game/Level/Lane Config", order = 0)]
    public class LaneConfig : ScriptableObject
    {
        public float SpawnOffset;
        
        public float SpawnRate;
        
        public float EntitySpeed;
    }
}