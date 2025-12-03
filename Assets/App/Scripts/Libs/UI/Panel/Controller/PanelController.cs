using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Controller
{
    public abstract class PanelController
    {
        private readonly CanvasGroupView _groupView;

        protected PanelController(CanvasGroupView view)
        {
            _groupView = view;
        }

        public void SetInteractable(bool value) => _groupView.CanvasGroup.interactable = value;
        
        public UniTask ShowAnimated() => _groupView.ShowAnimated();

        public UniTask HideAnimated() => _groupView.HideAnimated();

        public void Show() => _groupView.Show();

        public void Hide() => _groupView.Hide();

        public void Destroy() => Object.Destroy(_groupView.gameObject);
    }
}