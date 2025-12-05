using UnityEngine;

namespace App.Scripts.Game.Level.Config.Lane
{
    [CreateAssetMenu(fileName = "Default Lane Config", menuName = "Scriptable Object/Game/Level/Lane Config", order = 0)]
    public class LaneConfig : ScriptableObject
    {
        public float SpawnRate;
        
        public float EntitySpeed;

        public bool IsDirectionReversed;
    }
}