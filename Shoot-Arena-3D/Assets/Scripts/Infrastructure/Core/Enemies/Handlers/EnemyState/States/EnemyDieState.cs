using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyDieState : BaseEnemyState
    {
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;

        public EnemyDieState(IEnemyRuntimeData enemyRuntimeData)
        {
            _enemyRuntimeData = enemyRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();
            
            _enemyRuntimeData.Enemy.Die();
        }
    }
}