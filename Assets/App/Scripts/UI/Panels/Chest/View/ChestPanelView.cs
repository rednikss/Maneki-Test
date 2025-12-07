using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Fade;
using App.Scripts.Libs.UI.AnimatedView.Int;
using App.Scripts.UI.Elements.Lock;
using UnityEngine;

namespace App.Scripts.UI.Panels.Chest.View
{
    public class ChestPanelView : FadeCanvasGroupView
    {
        public Lock Lock;

        public Transform KeyPanel;

        public AnimatedIntView CounterView;
    }
}