using UnityEngine;

namespace App.Scripts.Game.Modules.Follower.Config
{
    [CreateAssetMenu(fileName = "Default Following Config", menuName = "Scriptable Object/Game/Follow Config", order = 0)]
    public class FollowConfig : ScriptableObject
    {
        public Vector3 FollowerDistance;

        public float FollowSpeed;
        
        public Vector3 TargetLookPointDelta;
    }
}