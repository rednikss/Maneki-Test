using System.Collections.Generic;

namespace App.Scripts.Libs.Mechanics.Time.Timer
{
    public class Timer : ITickable
    {
        private float _currentTime;

        private readonly List<ITickable> _tickables = new();

        public void Tick(float deltaTime)
        {
            _currentTime += deltaTime;

            foreach (var t in _tickables)
            {
                t.Tick(deltaTime);
            }
        }

        public void AddTickable(ITickable tickable) => _tickables.Add(tickable);

        public void RemoveTickable(ITickable tickable) => _tickables.Remove(tickable);

        public float GetCurrentTime() => _currentTime;
    }
}