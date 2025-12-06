using UnityEngine;

namespace App.Scripts.Game.Level.Config
{
    [CreateAssetMenu(fileName = "Default Level Config", menuName = "Scriptable Object/Game/Level/Level Config", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public Vector3 StartPlayerPosition;
    }
}