using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemyPrepareAttackState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public EnemyPrepareAttackState(
            IEnemyStateService enemyStateService,
            IEnemyRuntimeData enemyRuntimeData,
            IPlayerRuntimeData playerRuntimeData
            )
        {
            _enemyStateService = enemyStateService;
            _enemyRuntimeData = enemyRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            CheckDistance();
        }

        private void CheckDistance()
        {
            if (IsPlayerClose())
            {
                _enemyStateService.EnterState<EnemyAttackState>();
            }
            else
            {
                _enemyStateService.EnterState<EnemyMoveToState>();
            }
        }

        private bool IsPlayerClose()
        {
            float distance = Vector3.Distance(_playerRuntimeData.Player.Transform.position, _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position);
            
            return distance <= _enemyRuntimeData.Enemy.ConfigurationData.EnemyAttackRangeValue;
        }
    }
}