using App.Scripts.Game.Entity.Obstacle.Base;
using App.Scripts.Game.Entity.Obstacle.Base.Config;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Entity.Obstacle.Pool
{
    public class ObstaclePool : MonoBehaviourPool<ObstacleBase>
    {
        private ObstacleConfig _obstacleConfig;
        
        public void Construct(ObstacleConfig obstacleConfig)
        {
            _obstacleConfig = obstacleConfig;
        }
        
        protected override ObstacleBase Create()
        {
            var obj = base.Create();
            
            obj.AttackingEntity.Construct(_obstacleConfig.Damage);
            obj.ObstacleAnimator.Construct();
            
            return obj;
        }
    }
}