using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.Config
{
    [CreateAssetMenu(fileName = "Animation Config", menuName = "Scriptable Object/View/Animation Config", order = 0)]
    public class ConfigAnimation : ScriptableObject
    {
        [Min(0)] 
        public float duration = 0.25f;

        public Ease inEase = Ease.OutSine;
        
        public Ease outEase = Ease.InSine;
    }
}