using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyRechargeState : BaseEnemyState
    {
        private readonly IEnemyStateHandler _enemyStateHandler = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        
        public EnemyRechargeState(
            IEnemyStateHandler enemyStateHandler,
            IEnemyRuntimeData enemyRuntimeData
            )
        {
            _enemyStateHandler = enemyStateHandler;
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
            return Time.realtimeSinceStartup - _enemyRuntimeData.AttackStartTime > _enemyRuntimeData.Enemy.DamageData.AttackInterval;
        }

        private void ChangeState()
        {
            _enemyStateHandler.EnterState<EnemyPrepareAttackState>();
        }
    }
}