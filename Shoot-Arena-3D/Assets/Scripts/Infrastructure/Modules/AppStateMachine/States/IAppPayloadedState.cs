namespace ShootArena.Infrastructure.Modules.AppStateMachine.States
{
    public interface IAppPayloadedState<TPayLoad> : IAppExitableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface ITwoPayloadedState<TFirstPayload, TSecondPayload> : IAppExitableState
    {
        void Enter(TFirstPayload firstPayLoad, TSecondPayload secondPayload);
    }

    public interface IThreePayloadedState<TFirstPayload, TSecondPayload, TThirdPayload> : IAppExitableState
    {
        void Enter(TFirstPayload firstPayLoad, TSecondPayload secondPayload, TThirdPayload thirdPayload);
    }
}