using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using ShootArena.Infrastructure.Core.Services.EnemyState.States;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.Implementation
{
    public class EnemyStateService : IEnemyStateService, ITickable
    {
        private Dictionary<Type, IEnemyState> _enemyStates = null;
        private IEnemyState _currentState = null;
        
        [Inject]
        public void Construct(
            EnemyIdleState idleState,
            EnemyMoveToState moveToState,
            EnemyPrepareAttackState prepareAttackState,
            EnemyAttackState attackState,
            EnemyRechargeState rechargeState,
            EnemyDieState dieState
            )
        {
            _enemyStates = new Dictionary<Type, IEnemyState>
            {
                [typeof(EnemyIdleState)] = idleState,
                [typeof(EnemyMoveToState)] = moveToState,
                [typeof(EnemyPrepareAttackState)] = prepareAttackState,
                [typeof(EnemyAttackState)] = attackState,
                [typeof(EnemyRechargeState)] = rechargeState,
                [typeof(EnemyDieState)] = dieState
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

        public void Tick()
        {
            _currentState?.Tick();
        }
    }
}