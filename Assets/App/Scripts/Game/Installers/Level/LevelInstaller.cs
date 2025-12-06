using System;
using System.Collections.Generic;
using App.Scripts.Game.Entity.Base.Obstacle.Config;
using App.Scripts.Game.Entity.Pool;
using App.Scripts.Game.Level.Config.Lane;
using App.Scripts.Game.Level.Lane.Base;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Handler;
using App.Scripts.Libs.Mechanics.Time.Tickable.Container;
using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Game.Installers.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleConfig _obstacleConfig;
        
        [SerializeField] private LaneData[] _lanes;

        [SerializeField] private EntityPool _pool;
            
        public override void InstallBindings(ServiceContainer container)
        {
            var handler = container.GetService<MonoTickableHandler>();
            var timer = container.GetService<Timer>();
            _pool.Construct(_obstacleConfig);
            
            var laneHandlersList = new List<LaneHandler>();
            foreach (var laneData in _lanes)
            {
                laneData.LaneBase.Construct(_pool);
                var laneHandler = new LaneHandler(laneData.LaneBase, laneData.Config, timer);
                
                laneHandlersList.Add(laneHandler);
            }

            var laneHandlersContainer = new TickableContainer<LaneHandler>(laneHandlersList);
            container.SetServiceSelf(laneHandlersContainer);
            handler.AddTickable(laneHandlersContainer);
        }
    }

    [Serializable]
    public class LaneData
    {
        public LaneConfig Config;
        
        public LaneBase LaneBase;
    }
}