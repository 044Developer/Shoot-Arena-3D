using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyPrepareAttackState : BaseEnemyState
    {
        public override void Enter()
        {
            base.Enter();
            
            /*
             float distance = Vector3.Distance(playerRuntime.Player.Transform.position, transform.position);

            ChangeState(
                distance > ConfigurationData.EnemyAttackRangeValue
                ? EnemyStateType.MoveToState
                : EnemyStateType.PrepareAttackState
                );
             */
        }
    }
}