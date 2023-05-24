using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using ShootArena.Infrastructure.Core.Services.EnemyState.States;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.Implementation
{
    public class EnemyStateService : IEnemyStateService
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        
        private Dictionary<Type, IEnemyState> _enemyStates = null;
        private IEnemyState _currentState = null;

        public EnemyStateService(
            IPlayerRuntimeData playerRuntimeData
            )
        {
            _playerRuntimeData = playerRuntimeData;
        }

        public void RegisterService(IEnemyRuntimeData enemyRuntimeData)
        {
            _enemyStates = new Dictionary<Type, IEnemyState>()
            {
                [typeof(EnemyIdleState)] = new EnemyIdleState(),
                [typeof(EnemySearchState)] = new EnemySearchState(this, _playerRuntimeData, enemyRuntimeData),
                [typeof(EnemyMoveToState)] = new EnemyMoveToState(this, enemyRuntimeData),
                [typeof(EnemyPrepareAttackState)] = new EnemyPrepareAttackState(this, enemyRuntimeData),
                [typeof(EnemyAttackState)] = new EnemyAttackState(this, enemyRuntimeData),
                [typeof(EnemyRechargeState)] = new EnemyRechargeState(this, enemyRuntimeData),
                [typeof(EnemyDieState)] = new EnemyDieState(enemyRuntimeData)
            };
        }

        public void EnterState<TState>() where TState : IEnemyState
        {
            IEnemyState tempState = GetState<TState>();
            
            if (IsInSameState(tempState))
                return;
            
            ExitCurrentState();
            
            EnterNewState(tempState);
        }

        private bool IsInSameState(IEnemyState nextState) => 
            _currentState == nextState;

        private void EnterNewState(IEnemyState newState)
        {
            _currentState = newState;
            _currentState.Enter();
        }

        private IEnemyState GetState<TState>() where TState : IEnemyState
        {
            return _enemyStates[typeof(TState)];
        }
        
        private void ExitCurrentState()
        {
            _currentState?.Exit();
            _currentState = null;
        }
    }
}