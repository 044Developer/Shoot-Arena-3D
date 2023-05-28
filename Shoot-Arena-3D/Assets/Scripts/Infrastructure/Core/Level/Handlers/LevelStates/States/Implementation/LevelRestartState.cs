using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelRestartState : BaseLevelState
    {
        private readonly IPlayerSpawnService _playerSpawnService = null;
        private readonly IPlayerSetUpHandler _playerSetUpHandler = null;
        private readonly ILevelStatesHandler _levelStatesHandler = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;
        private readonly IHUDRuntimeData _hudRuntimeData = null;
        private readonly ILevelTimingRuntimeData _timingRuntimeData = null;

        public LevelRestartState(
            IPlayerSpawnService playerSpawnService,
            IPlayerSetUpHandler playerSetUpHandler,
            ILevelStatesHandler levelStatesHandler,
            IEnemyRegistryService enemyRegistryService,
            IHUDRuntimeData hudRuntimeData,
            ILevelTimingRuntimeData timingRuntimeData
            )
        {
            _playerSpawnService = playerSpawnService;
            _playerSetUpHandler = playerSetUpHandler;
            _levelStatesHandler = levelStatesHandler;
            _enemyRegistryService = enemyRegistryService;
            _hudRuntimeData = hudRuntimeData;
            _timingRuntimeData = timingRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();

            ResetLevelTime();
            
            ResetPlayer();

            StartLevel();
        }

        private void ResetLevelTime()
        {
            _timingRuntimeData.CurrenLevelTime = 0f;
        }
        
        private void ResetPlayer()
        {
            _enemyRegistryService.KillAllEnemies();
            _playerSetUpHandler.SetUpPlayer();
            _playerSpawnService.RespawnPlayer();
        }
        
        private void StartLevel()
        {
            _hudRuntimeData.OnLevelReset?.Invoke();
            _levelStatesHandler.ChangeLevelStateTo<LevelEnterState>();
        }
    }
}