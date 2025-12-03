using System;
using System.Collections.Generic;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.Patterns.StateMachine.State;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Libs.Patterns.StateMachine
{
    public class GameStateMachine : ITickable
    {
        private readonly Dictionary<Type, GameState> _states = new();

        private GameState _currentState;
        
        public void AddState(GameState state)
        {
            _states[state.GetType()] = state;
        }

        public void ChangeState<T>()
        {
            if (!_states.TryGetValue(typeof(T), out var state)) return;
            
            SetState(state);
        }

        private async void SetState(GameState value)
        {
            await (_currentState?.OnExitState() ?? UniTask.CompletedTask);
            _currentState = value;
            await (_currentState?.OnEnterState() ?? UniTask.CompletedTask);
        }

        public void Tick(float deltaTime)
        {
            _currentState?.Tick(deltaTime);
        }
    }
}