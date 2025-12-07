using UnityEngine;

namespace App.Scripts.UI.Panels.Chest.Config
{
    [CreateAssetMenu(fileName = "Default Chest Panel Config", menuName = "Scriptable Object/UI/Chest Panel Config", order = 0)]
    public class ChestPanelConfig : ScriptableObject
    {
        public int KeysToOpen;
        
        public int KeyCount;

        public Color[] KeyColors;
    }
}