using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyMoveToState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;

        public EnemyMoveToState(
            IEnemyStateService enemyStateService,
            IEnemyRuntimeData enemyRuntimeData
            )
        {
            _enemyStateService = enemyStateService;
            _enemyRuntimeData = enemyRuntimeData;
        }

        public override void Tick()
        {   
            _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.destination = _enemyRuntimeData.Player.Transform.position;
            
            if (!IsEnemyReachedTarget())
                return;
            
            _enemyStateService.EnterState<EnemyPrepareAttackState>();
        }
        
        private bool IsEnemyReachedTarget()
        {
            return _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.remainingDistance <= _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.stoppingDistance;
        }
    }
}