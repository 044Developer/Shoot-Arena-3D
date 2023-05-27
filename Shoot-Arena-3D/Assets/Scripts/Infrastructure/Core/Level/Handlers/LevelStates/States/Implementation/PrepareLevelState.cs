using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn;
using ShootArena.Infrastructure.Core.Services.Initialize;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class PrepareLevelState : BaseLevelState
    {
        private readonly ILevelInitializeService _initializeService = null;
        private readonly IEnvironmentSpawnService _environmentSpawnService = null;
        private readonly IPlayerSpawnService _playerSpawnService = null;
        private readonly ILevelStatesHandler _levelStatesHandler = null;

        public PrepareLevelState(
            ILevelInitializeService initializeService,
            IEnvironmentSpawnService environmentSpawnService,
            IPlayerSpawnService playerSpawnService,
            ILevelStatesHandler levelStatesHandler
            )
        {
            _initializeService = initializeService;
            _environmentSpawnService = environmentSpawnService;
            _playerSpawnService = playerSpawnService;
            _levelStatesHandler = levelStatesHandler;
        }

        public override void Enter()
        {
            base.Enter();

            _initializeService.ReadLevelScenario();
            _environmentSpawnService.InitEnvironment();
            _playerSpawnService.SpawnPlayer();
            
            _levelStatesHandler.ChangeLevelStateTo<LevelEnterState>();
        }
    }
}