using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelRestartState : BaseLevelState
    {
        private readonly IPlayerSpawnService _playerSpawnService = null;
        private readonly IPlayerSetUpHandler _playerSetUpHandler = null;

        public LevelRestartState(
            IPlayerSpawnService playerSpawnService,
            IPlayerSetUpHandler playerSetUpHandler
            )
        {
            _playerSpawnService = playerSpawnService;
            _playerSetUpHandler = playerSetUpHandler;
        }

        public override void Enter()
        {
            base.Enter();
            
            ResetPlayer();

            StartLevel();
        }
        
        private void ResetPlayer()
        {
            _playerSetUpHandler.SetUpPlayer();
            _playerSpawnService.RespawnPlayer();
        }
        
        private void StartLevel()
        {
        }
    }
}