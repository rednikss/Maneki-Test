using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Fade
{
    public class FadeCanvasGroupView : CanvasGroupView
    {
        public override async UniTask ShowAnimated()
        {
            CurrentTween.Kill();
            
            base.Show();
            
            CurrentTween = CanvasGroup.DOFade(1, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject);
            
            await CurrentTween.AwaitForComplete();
        }

        public override async UniTask HideAnimated()
        {
            CurrentTween.Kill();

            CurrentTween = CanvasGroup.DOFade(0, config.duration)
                .SetEase(config.outEase)
                .SetLink(gameObject);

            await CurrentTween.AwaitForComplete();
            
            base.Hide();
        }

        public override void Show()
        {
            CanvasGroup.alpha = 1;
            base.Show();
        }
        
        public override void Hide()
        {
            CanvasGroup.alpha = 0;
            base.Hide();
        }
    }
}
