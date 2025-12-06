using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Libs.Mechanics.Time.Handler
{
    public class MonoTickableHandler : MonoBehaviour
    {
        private readonly List<ITickable> _tickables = new();
        
        private void Update()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick(UnityEngine.Time.deltaTime);
            }
        }

        public void AddTickable(ITickable tickable) => _tickables.Add(tickable);
        
        public void RemoveTickable(ITickable tickable) => _tickables.Remove(tickable);
    }
}