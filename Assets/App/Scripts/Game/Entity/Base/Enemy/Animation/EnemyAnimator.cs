using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Game.Entity.Base.Enemy.Animation
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private string _attackTriggerName;

        private int _attackTriggerHash;

        private Timer _timer;

        private float _attackRate;

        private Timer.TimerEvent _lastEvent;
        
        public void Construct(float attackRate, Timer timer)
        {
            _attackRate = attackRate;
            _timer = timer;
            
            _attackTriggerHash = Animator.StringToHash(_attackTriggerName);
        }

        public void Activate()
        {
            _lastEvent = _timer.AddEvent(Attack, _attackRate);
        }

        public void Deactivate()
        {
            _animator.ResetTrigger(_attackTriggerHash);
            
            if (_lastEvent == null) return;
            
            _timer.CancelEvent(_lastEvent);
        }
        
        public void Attack()
        {
            _animator.SetTrigger(_attackTriggerHash);
            _lastEvent = _timer.AddEvent(Attack, _attackRate);
        }
    }
}