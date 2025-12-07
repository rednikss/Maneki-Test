using System.Text;
using App.Scripts.Libs.UI.AnimatedView.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.Int
{
    public class AnimatedIntView : MonoBehaviour
    {
        [SerializeField] private ConfigAnimation config;
        
        [SerializeField] protected TextMeshProUGUI label;

        private StringBuilder _builder = new();
        
        private int _value;

        public void Construct(string prefix, string postfix, int newValue = 0)
        {
            _value = newValue;
            _builder = new(prefix);
            _builder.Append(_value);
            _builder.Append(postfix);
            
            label.text = _builder.ToString();
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