using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyRechargeState : BaseEnemyState
    {
        public override void Tick()
        {
            base.Tick();
            
            /*
             if (_currentEnemyState != EnemyStateType.RechargeState)
                return;

            if (_currentRechargeTime < ConfigurationData.EnemyAttackIntervalValue)
            {
                _currentRechargeTime += Time.deltaTime;
            }
            else
            {
                ChangeState(EnemyStateType.MoveToState);
            }
             */
        }
    }
}