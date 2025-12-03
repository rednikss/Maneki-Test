using App.Scripts.Libs.Mechanics.Time.Timer;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Libs.Patterns.StateMachine.State
{
    public abstract class GameState : ITickable
    {
        private readonly Timer _timer;

        protected GameState(Timer timer)
        {
            _timer = timer;
        }

        public void AddTickable(ITickable tickable) => _timer.AddTickable(tickable);
        
        public virtual UniTask OnEnterState() => UniTask.CompletedTask;
        
        public void Tick(float deltaTime) => _timer.Tick(deltaTime);

        public virtual UniTask OnExitState() => UniTask.CompletedTask;
    }
}