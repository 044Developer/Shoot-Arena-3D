using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using Zenject;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.Implementation
{
    public class LevelStateHandler : ILevelStatesHandler
    {
        private Dictionary<Type, ILevelState> _levelStates = null;
        private ILevelState _activeState = null;

        [Inject]
        public void Construct(
            PrepareLevelState prepareLevelState,
            LevelEnterState levelEnterState,
            LevelPauseState levelPauseState,
            LevelResumeState levelResumeState,
            LevelExitState levelExitState,
            LevelRestartState levelRestartState
            )
        {
            _levelStates = new Dictionary<Type, ILevelState>
            {
                [typeof(PrepareLevelState)] = prepareLevelState,
                [typeof(LevelEnterState)] = levelEnterState,
                [typeof(LevelPauseState)] = levelPauseState,
                [typeof(LevelResumeState)] = levelResumeState,
                [typeof(LevelExitState)] = levelExitState,
                [typeof(LevelRestartState)] = levelRestartState,
            };
        }

        public void ChangeLevelStateTo<TState>() where TState : class, ILevelState
        {
            TState tempState = ChangeState<TState>();
            tempState.Enter();
        }

        private TState ChangeState<TState>() where TState : class, ILevelState
        {
            _activeState?.Exit();
            TState tempState = GetState<TState>();
            _activeState = tempState;

            return tempState;
        }

        private TState GetState<TState>() where TState : class, ILevelState
        {
            return _levelStates[typeof(TState)] as TState;
        }
    }
}