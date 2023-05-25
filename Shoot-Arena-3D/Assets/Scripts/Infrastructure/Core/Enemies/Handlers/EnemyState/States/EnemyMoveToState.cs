using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyMoveToState : BaseEnemyState
    {
        private readonly IEnemyStateHandler _enemyStateHandler = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public EnemyMoveToState(
            IEnemyStateHandler enemyStateHandler,
            IEnemyRuntimeData enemyRuntimeData,
            IPlayerRuntimeData playerRuntimeData
            )
        {
            _enemyStateHandler = enemyStateHandler;
            _enemyRuntimeData = enemyRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }

        public override void Tick()
        {   
            base.Tick();
            
            _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.destination = _playerRuntimeData.Player.View.Transform.position;
            
            if (!IsEnemyReachedTarget())
                return;
            
            _enemyStateHandler.EnterState<EnemyPrepareAttackState>();
        }
        
        private bool IsEnemyReachedTarget()
        {
            return _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.remainingDistance <= _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.stoppingDistance;
        }
    }
}