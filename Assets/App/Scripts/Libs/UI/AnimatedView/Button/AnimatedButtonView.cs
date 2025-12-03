using App.Scripts.Libs.UI.AnimatedView.Button.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.Libs.UI.AnimatedView.Button
{
    public class AnimatedButtonView : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private ConfigButtonAnimation config;
        
        [SerializeField] private UnityEngine.UI.Button button;
        
        private UniTask Press()
        { 
            return transform.DOScale(Vector3.one * config.pressedScale, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject)
                .ToUniTask();
        }

        private UniTask UnPress()
        {
            return transform.DOScale(Vector3.one, config.duration)
                .SetEase(config.outEase)
                .SetLink(gameObject, LinkBehaviour.CompleteOnDisable)
                .ToUniTask();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (button.interactable && !DOTween.IsTweening(transform)) Press();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UnPress();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UnPress();
        }
    }
}