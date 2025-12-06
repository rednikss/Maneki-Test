using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Entity.Movement.Dash.Config
{
    [CreateAssetMenu(fileName = "Default Dash Config", menuName = "Scriptable Object/Game/Entity/Dash Config", order = 0)]
    public class DashConfig : ScriptableObject
    {
        [Min(0f)]
        public float DashLength;
        
        public Ease DashEase;
        
        [Min(0f)]
        public float DashTime;

        public LayerMask DashLayerMask;
    }
}