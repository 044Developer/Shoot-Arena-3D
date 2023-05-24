using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using ShootArena.Infrastructure.Core.Services.EnemyState.States;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.Implementation
{
    public class EnemyStateService : IEnemyStateService
    {
        private readonly Dictionary<Type, IEnemyState> _enemyStates = null;
        private IEnemyState _currentState = null;

        public EnemyStateService()
        {
            _enemyStates = new Dictionary<Type, IEnemyState>
            {
                [typeof(EnemySearchState)] = new EnemySearchState(),
                [typeof(EnemyMoveToState)] = new EnemyMoveToState(),
                [typeof(EnemyTargetReachedState)] = new EnemyTargetReachedState(),
                [typeof(EnemyPrepareAttackState)] = new EnemyPrepareAttackState(),
                [typeof(EnemyAttackState)] = new EnemyAttackState(),
                [typeof(EnemyRechargeState)] = new EnemyRechargeState(),
                [typeof(EnemyDieState)] = new EnemyDieState()
            };
        }

        public void EnterState<TState>() where TState : IEnemyState
        {
            IEnemyState temp = GetNextState<TState>();

            if (IsInSameState(temp))
                return;
            
            ExitCurrentState();
            
            EnterNewState(temp);
        }

        private bool IsInSameState(IEnemyState nextState)=> 
            _currentState == nextState;

        private IEnemyState GetNextState<TState>() where TState : IEnemyState => 
            _enemyStates[typeof(TState)];

        private void EnterNewState(IEnemyState enemyState)
        {
            _currentState = enemyState;
            _currentState?.Enter();
        }
        
        private void ExitCurrentState() => 
            _currentState?.Exit();

        public void Tick()
        {
            _currentState?.Tick();
        }
    }
}