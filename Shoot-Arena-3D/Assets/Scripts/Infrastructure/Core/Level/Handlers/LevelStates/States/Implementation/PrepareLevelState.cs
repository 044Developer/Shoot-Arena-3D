using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn;
using ShootArena.Infrastructure.Core.Services.Initialize;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class PrepareLevelState : BaseLevelState
    {
        private readonly ILevelInitializeService _initializeService = null;
        private readonly IEnvironmentSpawnService _environmentSpawnService = null;
        private readonly IPlayerSpawnService _playerSpawnService = null;
        private readonly ILevelStatesHandler _levelStatesHandler = null;
        private readonly IHUDRuntimeData _hudRuntimeData = null;

        public PrepareLevelState(
            ILevelInitializeService initializeService,
            IEnvironmentSpawnService environmentSpawnService,
            IPlayerSpawnService playerSpawnService,
            ILevelStatesHandler levelStatesHandler,
            IHUDRuntimeData hudRuntimeData
            )
        {
            _initializeService = initializeService;
            _environmentSpawnService = environmentSpawnService;
            _playerSpawnService = playerSpawnService;
            _levelStatesHandler = levelStatesHandler;
            _hudRuntimeData = hudRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();

            _initializeService.ReadLevelScenario();
            _environmentSpawnService.InitEnvironment();
            _playerSpawnService.SpawnPlayer();
            
            _hudRuntimeData.OnLevelReset?.Invoke();
            _levelStatesHandler.ChangeLevelStateTo<LevelEnterState>();
        }
    }
}