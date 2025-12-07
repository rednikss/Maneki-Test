using System.Collections.Generic;
using App.Scripts.Game.Commands.Enemy.Activate;
using App.Scripts.Game.Commands.Restart;
using App.Scripts.Game.Entity.Base.Enemy;
using App.Scripts.Game.Entity.Base.Player;
using App.Scripts.Game.Entity.Base.Player.Config;
using App.Scripts.Game.Entity.Pool.Enemy;
using App.Scripts.Game.Level.Config;
using App.Scripts.Game.Level.Lane.Handler;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Initializable;
using App.Scripts.Libs.Mechanics.Time.Tickable.Container;
using App.Scripts.Libs.Mechanics.Time.Tickable.Handler;
using App.Scripts.Libs.Mechanics.Trigger;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Game.Controller;
using UnityEngine;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : MonoInitializable
    {
        [SerializeField] private LevelConfig _levelConfig;

        [SerializeField] private PlayerConfig _playerConfig;
        
        [SerializeField] private TriggerZone _enemyActivateTrigger;

        [SerializeField] private EnemyPool _enemyPool;
        
        private PanelManager _panelManager;

        private IEnumerable<LaneHandler> _laneHandlers;

        private PlayerBase _playerBase;

        private ITickableHandler _handler;
        
        public void Construct(PanelManager panelManager, 
            IEnumerable<LaneHandler> laneHandlers, 
            PlayerBase playerBase,
            ITickableHandler handler)
        {
            _panelManager = panelManager;
            _laneHandlers = laneHandlers;
            _playerBase = playerBase;
            _handler = handler;
        }

        public override async void Init()
        {
            foreach (var laneHandler in _laneHandlers) laneHandler.Activate();
    
            var enemies = new List<EnemyBase>();
            foreach (var enemyPos in _levelConfig.EnemyStartPositions)
            {
                var enemy = _enemyPool.Get();
                enemies.Add(enemy);
                enemy.transform.SetPositionAndRotation(enemyPos, Quaternion.identity);
            }
            
            var command = new ActivateEnemiesCommand(_handler, enemies);
            _enemyActivateTrigger.Construct(_playerBase.GetType(), command);

            var tickableEnemies = new TickableContainer<EnemyBase>(enemies);
            var restartGameCommand = new RestartGameCommand(_laneHandlers, _handler, 
                tickableEnemies, _enemyPool, _playerBase, this);
            _playerBase.DamageableEntity.Construct(_playerConfig.Health, restartGameCommand);
            _playerBase.transform.position = _levelConfig.PlayerStartPosition;
            
            var panel = _panelManager.GetPanel<GamePanelController>();
            await panel.ShowAnimated();
        }
        
        
    }
}