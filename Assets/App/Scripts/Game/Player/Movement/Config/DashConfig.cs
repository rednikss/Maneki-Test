using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Player.Movement.Config
{
    [CreateAssetMenu(fileName = "Default Dash Config", menuName = "Scriptable Object/Game/Dash Config", order = 0)]
    public class DashConfig : ScriptableObject
    {
        public float DashLength;
        
        public Ease DashEase;
        
        public float DashTime;

        public LayerMask DashLayerMask;
    }
}