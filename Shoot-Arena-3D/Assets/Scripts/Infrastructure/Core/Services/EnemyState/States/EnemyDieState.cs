using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
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