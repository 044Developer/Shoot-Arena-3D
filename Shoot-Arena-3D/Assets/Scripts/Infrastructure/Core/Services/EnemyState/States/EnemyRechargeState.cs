using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyRechargeState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        
        public EnemyRechargeState(
            IEnemyStateService enemyStateService,
            IEnemyRuntimeData enemyRuntimeData
            )
        {
            _enemyStateService = enemyStateService;
            _enemyRuntimeData = enemyRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();
            
            _enemyRuntimeData.AttackStartTime = Time.realtimeSinceStartup;
        }

        public override void Tick()
        {
            base.Tick();

            if (!HasRecharged())
                return;
            
            ChangeState();
        }

        private bool HasRecharged()
        {
            return Time.realtimeSinceStartup - _enemyRuntimeData.AttackStartTime > _enemyRuntimeData.Enemy.ConfigurationData.EnemyAttackIntervalValue;
        }

        private void ChangeState()
        {
            _enemyStateService.EnterState<EnemyPrepareAttackState>();
        }
    }
}