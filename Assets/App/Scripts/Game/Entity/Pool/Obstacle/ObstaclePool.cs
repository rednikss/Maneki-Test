using App.Scripts.Game.Entity.Base.Obstacle;
using App.Scripts.Game.Entity.Base.Obstacle.Config;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Entity.Pool.Obstacle
{
    public class ObstaclePool : MonoBehaviourPool<ObstacleBase>
    {
        private ObstacleConfig _obstacleConfig;
        
        public void Construct(ObstacleConfig obstacleConfig)
        {
            _obstacleConfig = obstacleConfig;
            
            CreateStartPool();
        }
        
        protected override ObstacleBase Create()
        {
            var obj = base.Create();
            
            obj.AttackingEntity.Construct(_obstacleConfig.AttackLayerMask, _obstacleConfig.Damage);
            obj.ObstacleAnimator.Construct();
            
            return obj;
        }
    }
}