using App.Scripts.Game.Level.Lane.Base;
using App.Scripts.Game.Level.Lane.Base.Config;
using App.Scripts.Libs.Mechanics.Time.Tickable;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Level.Lane.Handler
{
    public class LaneHandler : ITickable
    {
        private readonly LaneBase _lane;

        private readonly CycleSpawnCommand _command;
        
        public LaneHandler(LaneBase lane, LaneConfig config, Timer timer)
        {
            _lane = lane;

            _command = new CycleSpawnCommand(config, _lane, timer);
        }

        public void Activate()
        {
            _command.Execute();
        }

        public void Deactivate()
        {
            _command.Cancel();
            _lane.ClearLane();
        }
        
        public void Tick(float deltaTime)
        {
            _lane.Tick(deltaTime);
        }

        private class CycleSpawnCommand : ICommand
        {
            private readonly LaneConfig _config;
            
            private readonly LaneBase _lane;

            private readonly Timer _timer;

            private Timer.TimerEvent _timerEvent;
            
            public CycleSpawnCommand(LaneConfig config, LaneBase lane, Timer timer)
            {
                _config = config;
                _lane = lane;
                _timer = timer;
            }

            public void Execute()
            {
                _lane.AddEntity(_config.EntitySpeed);
                _timerEvent = _timer.AddEvent(Execute, _config.SpawnRate);
            }

            public void Cancel()
            {
                if (_timerEvent == null) return;
                _timer.CancelEvent(_timerEvent);
            }
        }
    }
}