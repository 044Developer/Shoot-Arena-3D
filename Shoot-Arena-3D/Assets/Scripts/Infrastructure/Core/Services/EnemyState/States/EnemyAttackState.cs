using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyAttackState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;

        public EnemyAttackState(IEnemyStateService enemyStateService, IEnemyRuntimeData enemyRuntimeData)
        {
            _enemyStateService = enemyStateService;
            _enemyRuntimeData = enemyRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();
            
            if (IsRangeEnemyAttack())
            {
                AttackRange();
            }
        }

        public override  void Tick()
        {
            if (!IsMeleeEnemyAttack())
                return;

            AttackMelee();
        }

        private void AttackMelee()
        {
            _enemyStateService.EnterState<EnemyDieState>();
        }

        private void AttackRange()
        {
            _enemyStateService.EnterState<EnemyPrepareAttackState>();
        }

        private bool IsMeleeEnemyAttack() => 
            _enemyRuntimeData.Enemy.ConfigurationData.AttackType == EnemyAttackType.Physical;
        private bool IsRangeEnemyAttack() => 
            _enemyRuntimeData.Enemy.ConfigurationData.AttackType == EnemyAttackType.Shooting;
    }
}