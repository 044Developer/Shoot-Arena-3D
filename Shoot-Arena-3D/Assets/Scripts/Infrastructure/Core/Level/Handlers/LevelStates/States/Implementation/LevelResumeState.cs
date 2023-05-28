using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelResumeState : BaseLevelState
    {
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;
        private readonly IEnemyRegistryService _enemyRegistryService;

        public LevelResumeState(
            ILevelTimingRuntimeData levelTimingRuntimeData,
            IEnemyRegistryService enemyRegistryService
            )
        {
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _enemyRegistryService = enemyRegistryService;
        }

        public override void Enter()
        {
            base.Enter();
            
            _levelTimingRuntimeData.IsLevelPaused = false;
            
            _enemyRegistryService.ResumeAllEnemies();
        }
    }
}