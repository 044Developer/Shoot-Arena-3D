using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyIdleState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;

        public EnemyIdleState(IEnemyStateService enemyStateService)
        {
            _enemyStateService = enemyStateService;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            _enemyStateService.EnterState<EnemyMoveToState>();
        }
    }
}