using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Tickable;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Game.Modules.Observer
{
    public class ObjectObserver<TObject> : ITickable where TObject : MonoBehaviour
    {
        private readonly List<TObject> _objects;
        
        private readonly ICommand _onZeroObjects;

        private readonly ITickableHandler _tickableHandler;

        public ObjectObserver(List<TObject> objects, ICommand onZeroObjects, ITickableHandler tickableHandler)
        {
            _objects = objects;
            _onZeroObjects = onZeroObjects;
            _tickableHandler = tickableHandler;
        }
        
        public void Tick(float deltaTime)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].gameObject.activeSelf) return;
            }
            
            _tickableHandler.RemoveTickable(this);
            _onZeroObjects.Execute();
        }
    }
}