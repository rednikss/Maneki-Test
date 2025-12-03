using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Libs.Mechanics.Time.TimeHandler
{
    public class MonoTimerHandler : MonoBehaviour
    {
        private Timer.Timer _timer;
        
        public void Construct(Timer.Timer timer)
        {
            _timer = timer;
        }
        
        private void Update()
        {
            _timer?.Tick(UnityEngine.Time.deltaTime);
        }

        public void AddTickable(ITickable tickable) => _timer.AddTickable(tickable);
        
        public void RemoveTickable(ITickable tickable) => _timer.RemoveTickable(tickable);
    }
}