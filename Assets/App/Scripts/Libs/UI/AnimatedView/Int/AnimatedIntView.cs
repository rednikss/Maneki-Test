using System.Text;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using App.Scripts.Libs.UI.AnimatedView.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.Int
{
    public class AnimatedIntView : MonoInitializable
    {
        [SerializeField] private ConfigAnimation config;
        
        [SerializeField] protected TextMeshProUGUI label;
        [SerializeField] protected string prefix;
        [SerializeField] protected string postfix;

        private StringBuilder _builder = new();
        private int _value;

        public override void Init()
        {
            _builder = new(prefix);
            _builder.Append(0);
            _builder.Append(postfix);
        }

        public void SetValue(int newValue)
        {
            _builder.Replace(_value.ToString(), newValue.ToString());
            label.text = _builder.ToString();
            
            _value = newValue;
        }
        
        public UniTask SetValueAnimated(int newValue)
        {
            return DOTween.To(GetValue, SetValue, newValue, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject)
                .ToUniTask();
        }
        
        
        public int GetValue() => _value;
    }
}