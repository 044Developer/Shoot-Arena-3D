namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class GameResumeState : IAppState
    {
        private readonly IAppStateMachine _stateMachine = null;

        public GameResumeState(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
        }
        
        public void Exit()
        {
        }
    }
}