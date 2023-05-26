namespace ShootArena.Infrastructure.Modules.AppStateMachine.States
{
    public abstract class AppBaseState : IAppState
    {
        public virtual void Exit()
        {
        }

        public virtual void Enter()
        {
        }
    }
}