using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Modules.AppStateMachine.States;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using Zenject;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.Implementation
{
    public class AppStateMachine : IAppStateMachine
    {
        private Dictionary<Type, IAppExitableState> _gameStates = null;
        private IAppExitableState _activeState = null;

        [Inject]
        public void Construct(
            BoostrapState boostrapState,
            SceneLoadState sceneLoadState,
            AppOutOfFocusState appOutOfFocusState,
            AppBackToFocusState appBackToFocusState,
            AppMainMenuState appMainMenuState,
            AppCoreGameState appCoreGameState,
            AppQuitState appQuitState
            )
        {
            _gameStates = new Dictionary<Type, IAppExitableState>()
            {
                [typeof(BoostrapState)] = boostrapState,
                [typeof(SceneLoadState)] = sceneLoadState,
                [typeof(AppOutOfFocusState)] = appOutOfFocusState,
                [typeof(AppBackToFocusState)] = appBackToFocusState,
                [typeof(AppMainMenuState)] = appMainMenuState,
                [typeof(AppCoreGameState)] = appCoreGameState,
                [typeof(AppQuitState)] = appQuitState
            };
        }

        public void Enter<TState>() where TState : class, IAppState
        {
            TState tempState = ChangeState<TState>();
            tempState.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IAppPayloadedState<TPayLoad>
        {
            TState tempState = ChangeState<TState>();
            tempState.Enter(payLoad);
        }

        public void Enter<TState, TFirstPayLoad, TSecondPayLoad>(TFirstPayLoad firstPayLoad, TSecondPayLoad secondPayLoad) where TState : class, ITwoPayloadedState<TFirstPayLoad, TSecondPayLoad>
        {
            TState tempState = ChangeState<TState>();
            tempState.Enter(firstPayLoad, secondPayLoad);
        }

        public void Enter<TState, TFirstPayLoad, TSecondPayLoad, TThirdPayLoad>(TFirstPayLoad firstPayLoad, TSecondPayLoad secondPayLoad, TThirdPayLoad thirdPayLoad) where TState : class, IThreePayloadedState<TFirstPayLoad, TSecondPayLoad, TThirdPayLoad>
        {
            TState tempState = ChangeState<TState>();
            tempState.Enter(firstPayLoad, secondPayLoad, thirdPayLoad);
        }

        private TState ChangeState<TState>() where TState : class, IAppExitableState
        {
            _activeState?.Exit();
            TState tempState = GetState<TState>();
            _activeState = tempState;

            return tempState;
        }

        private TState GetState<TState>() where TState : class, IAppExitableState
        {
            return _gameStates[typeof(TState)] as TState;
        }
    }
}