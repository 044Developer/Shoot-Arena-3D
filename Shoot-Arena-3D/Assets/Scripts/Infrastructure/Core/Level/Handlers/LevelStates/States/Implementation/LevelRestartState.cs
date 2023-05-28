using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelRestartState : BaseLevelState
    {
        private readonly IPlayerSpawnService _playerSpawnService = null;
        private readonly IPlayerSetUpHandler _playerSetUpHandler = null;
        private readonly ILevelStatesHandler _levelStatesHandler = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;

        public LevelRestartState(
            IPlayerSpawnService playerSpawnService,
            IPlayerSetUpHandler playerSetUpHandler,
            ILevelStatesHandler levelStatesHandler,
            IEnemyRegistryService enemyRegistryService
            )
        {
            _playerSpawnService = playerSpawnService;
            _playerSetUpHandler = playerSetUpHandler;
            _levelStatesHandler = levelStatesHandler;
            _enemyRegistryService = enemyRegistryService;
        }

        public override void Enter()
        {
            base.Enter();
            
            ResetPlayer();

            StartLevel();
        }
        
        private void ResetPlayer()
        {
            _enemyRegistryService.KillAllEnemies();
            _playerSetUpHandler.SetUpPlayer();
            _playerSpawnService.RespawnPlayer();
        }
        
        private void StartLevel()
        {
            _levelStatesHandler.ChangeLevelStateTo<LevelEnterState>();
        }
    }
}