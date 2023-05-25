using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyMoveToState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public EnemyMoveToState(
            IEnemyStateService enemyStateService,
            IEnemyRuntimeData enemyRuntimeData,
            IPlayerRuntimeData playerRuntimeData
            )
        {
            _enemyStateService = enemyStateService;
            _enemyRuntimeData = enemyRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }

        public override void Tick()
        {   
            base.Tick();
            
            _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.destination = _playerRuntimeData.Player.View.Transform.position;
            
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