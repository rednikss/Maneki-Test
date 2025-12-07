using System;
using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Libs.Mechanics.Trigger
{
    public class TriggerZone : MonoBehaviour
    {
        private Type _triggeringType;
        
        private ICommand _command;
        
        private bool _isUsed;
        
        public void Construct(Type triggeringType, ICommand command)
        {
            _command = command;
            _triggeringType = triggeringType;
            _isUsed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isUsed) return;
            
            if (!other.TryGetComponent(_triggeringType, out _)) return;
            
            _command.Execute();
        }
    }
}