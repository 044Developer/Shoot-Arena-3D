using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyUpdater.Implementation
{
    public class EnemyUpdaterHandler : ITickable
    {
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;
        private readonly IEnemyHealthBarHandler _enemyHealthBarHandler;
        private readonly IEnemyStateHandler _enemyStateHandler = null;

        public EnemyUpdaterHandler(
            ILevelTimingRuntimeData levelTimingRuntimeData,
            IEnemyHealthBarHandler enemyHealthBarHandler,
            IEnemyStateHandler enemyStateHandler
            )
        {
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _enemyHealthBarHandler = enemyHealthBarHandler;
            _enemyStateHandler = enemyStateHandler;

        }
        
        public void Tick()
        {
            if (_levelTimingRuntimeData.IsLevelPaused)
                return;

            _enemyStateHandler.Tick();
            
            _enemyHealthBarHandler.Tick();
        }
    }
}