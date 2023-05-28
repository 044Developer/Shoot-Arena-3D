using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyIdleState : BaseEnemyState
    {
        private readonly IEnemyStateHandler _enemyStateHandler = null;

        public EnemyIdleState(IEnemyStateHandler enemyStateHandler)
        {
            _enemyStateHandler = enemyStateHandler;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            _enemyStateHandler.EnterState<EnemyMoveToState>();
        }
    }
}