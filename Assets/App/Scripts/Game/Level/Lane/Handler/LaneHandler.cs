using App.Scripts.Game.Level.Config.Lane;
using App.Scripts.Game.Level.Lane.Base;
using App.Scripts.Libs.Mechanics.Time.Timer;
using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Game.Level.Lane.Handler
{
    public class LaneHandler : ITickable
    {
        private readonly LaneConfig _config;
        
        private readonly LaneBase _lane;

        private readonly Timer _timer;

        private readonly CycleSpawnCommand _command;
        
        public LaneHandler(LaneBase lane, LaneConfig config, Timer timer)
        {
            _config = config;
            _lane = lane;
            _timer = timer;

            _command = new CycleSpawnCommand(_config, _lane, _timer);
        }

        public void Start()
        {
            _timer.AddEvent(
                _command.Execute, 
                _config.SpawnOffset);
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

            public CycleSpawnCommand(LaneConfig config, LaneBase lane, Timer timer)
            {
                _config = config;
                _lane = lane;
                _timer = timer;
            }

            public void Execute()
            {
                _lane.AddEntity(_config.EntitySpeed);
                _timer.AddEvent(Execute, _config.SpawnRate);
            }
        }
    }
}