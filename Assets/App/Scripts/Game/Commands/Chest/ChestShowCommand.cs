using App.Scripts.Libs.Mechanics.Trigger;
using App.Scripts.Libs.Patterns.Command.Default;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Commands.Chest
{
    public class ChestShowCommand : ICommand
    {
        private readonly TriggerZone _chestTransform;

        public ChestShowCommand(TriggerZone chestTransform)
        {
            _chestTransform = chestTransform;
        }
        
        public void Execute()
        {
            _chestTransform.transform.DOScale(Vector3.one, 0.25f)
                .SetEase(Ease.OutBounce)
                .SetLink(_chestTransform.gameObject);
        }
    }
}