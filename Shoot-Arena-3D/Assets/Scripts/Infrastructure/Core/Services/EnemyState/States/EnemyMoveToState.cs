using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyMoveToState : BaseEnemyState
    {
        public override void Tick()
        {
            base.Tick();
            /*
            if (_currentEnemyState != EnemyStateType.MoveToState)
                return;

            if (!IsEnemyReachedTarget())
                return;
            
            EnemyView.NavMeshAgent.destination = playerRuntime.Player.Transform.position;
            
            ChangeState(EnemyStateType.TargetReached);
            
            

        private bool IsEnemyReachedTarget()
        {
            return EnemyView.NavMeshAgent.remainingDistance <= EnemyView.NavMeshAgent.stoppingDistance;
        }
            */
        }
    }
}