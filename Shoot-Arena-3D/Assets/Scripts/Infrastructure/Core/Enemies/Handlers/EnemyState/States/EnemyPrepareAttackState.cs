using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyPrepareAttackState : BaseEnemyState
    {
        private readonly IEnemyStateHandler _enemyStateHandler = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public EnemyPrepareAttackState(
            IEnemyStateHandler enemyStateHandler,
            IEnemyRuntimeData enemyRuntimeData,
            IPlayerRuntimeData playerRuntimeData
            )
        {
            _enemyStateHandler = enemyStateHandler;
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
                _enemyStateHandler.EnterState<EnemyAttackState>();
            }
            else
            {
                _enemyStateHandler.EnterState<EnemyMoveToState>();
            }
        }

        private bool IsPlayerClose()
        {
            float distance = Vector3.Distance(_playerRuntimeData.Player.View.Transform.position, _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position);
            
            return distance <= _enemyRuntimeData.EnemyDamageData.AttackRange;
        }
    }
}