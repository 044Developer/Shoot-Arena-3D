using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;

namespace ShootArena.Infrastructure
{
    public class Game : IGame
    {
        private readonly IAppStateMachine _stateMachine = null;

        public Game(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void StartApplication()
        {
            _stateMachine.Enter<BoostrapState>();
        }

        public void QuitApplication()
        {
            _stateMachine.Enter<AppQuitState>();
        }
    }
}