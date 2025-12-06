using App.Scripts.Game.Entity.Movement.Dash;
using App.Scripts.Libs.Patterns.Command.Value;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Commands.Swipe
{
    public class PlayerSwipeCommand : ICommand<Vector2>
    {
        private readonly DashingEntity _dashingEntity;
        
        public PlayerSwipeCommand(DashingEntity dashingEntity)
        {
            _dashingEntity = dashingEntity;
        }

        public void Execute(Vector2 value)
        {
            var vector3Value = new Vector3(value.x, 0, value.y);
            
            _dashingEntity.Dash(-vector3Value);
        }
    }
}