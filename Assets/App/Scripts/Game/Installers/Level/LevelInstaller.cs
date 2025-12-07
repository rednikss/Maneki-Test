using System;
using System.Collections.Generic;
using App.Scripts.Game.Entity.Base.Enemy.Config;
using App.Scripts.Game.Entity.Base.Obstacle.Config;
using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Entity.Pool.Enemy;
using App.Scripts.Game.Entity.Pool.Obstacle;
using App.Scripts.Game.Level.Config;
using App.Scripts.Game.Level.Lane.Base;
using App.Scripts.Game.Level.Lane.Base.Config;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using App.Scripts.Libs.Mechanics.Time.Tickable.Container;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler.Fixed;
using App.Scripts.Libs.Mechanics.Time.Timer;
using UnityEngine;

namespace App.Scripts.Game.Installers.Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfig _levelConfig;
        
        [SerializeField] private LaneData[] _lanes;
        
        [SerializeField] private ObstacleConfig _obstacleConfig;

        [SerializeField] private ObstaclePool _obstaclePool;

        [SerializeField] private EnemyConfig _enemyConfig;

        [SerializeField] private EnemyPool _enemyPool;
        
        [SerializeField] private PlayerBase _playerPrefab;
        
        public override void InstallBindings(ServiceContainer container)
        {
            BuildLanes(container);

            var player = Instantiate(_playerPrefab, _levelConfig.PlayerStartPosition, Quaternion.identity);
            container.SetServiceSelf(player);
            
            _enemyPool.Construct(_enemyConfig, player.transform,
                container.GetService<Timer>(),
                container.GetService<FixedTickableHandler>());
            
            container.SetServiceSelf(_enemyPool);
        }

        private void BuildLanes(ServiceContainer container)
        {
            var handler = container.GetService<FixedTickableHandler>();
            var timer = container.GetService<Timer>();
            _obstaclePool.Construct(_obstacleConfig);

            var laneHandlersList = new List<LaneHandler>();
            foreach (var laneData in _lanes)
            {
                laneData.LaneBase.Construct(_obstaclePool);
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