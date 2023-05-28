using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelPauseState : BaseLevelState
    {
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;
        private readonly IEnemyRegistryService _enemyRegistryService;

        public LevelPauseState(
            ILevelTimingRuntimeData levelTimingRuntimeData,
            IEnemyRegistryService enemyRegistryService)
        {
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _enemyRegistryService = enemyRegistryService;
        }
        
        public override void Enter()
        {
            base.Enter();

            _levelTimingRuntimeData.IsLevelPaused = true;
            _enemyRegistryService.StopAllEnemies();
        }
    }
}