using App.Scripts.Game.Entity.Base.Obstacle;
using App.Scripts.Game.Entity.Base.Obstacle.Config;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Entity.Pool
{
    public class EntityPool : MonoBehaviourPool<ObstacleBase>
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

            return obj;
        }
    }
}