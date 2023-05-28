using ShootArena.Infrastructure.Modules.AppStateMachine.States;

namespace ShootArena.Infrastructure.Modules.AppStateMachine
{
    public interface IAppStateMachine
    {
        public void Enter<TState>() where TState : class, IAppState;
        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IAppPayloadedState<TPayLoad>;
        public void Enter<TState, TFirstPayLoad, TSecondPayLoad>(TFirstPayLoad firstPayLoad,
            TSecondPayLoad secondPayLoad) where TState : class, ITwoPayloadedState<TFirstPayLoad, TSecondPayLoad>;
        public void Enter<TState, TFirstPayLoad, TSecondPayLoad, TThirdPayLoad>(TFirstPayLoad firstPayLoad,
            TSecondPayLoad secondPayLoad, TThirdPayLoad thirdPayLoad) where TState : class, IThreePayloadedState<TFirstPayLoad, TSecondPayLoad, TThirdPayLoad>;
    }
}