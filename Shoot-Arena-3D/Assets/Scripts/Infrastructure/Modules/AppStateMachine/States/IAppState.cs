namespace ShootArena.Infrastructure.Modules.AppStateMachine.States
{
    public interface IAppState : IAppExitableState
    {
        void Enter();
    }
}