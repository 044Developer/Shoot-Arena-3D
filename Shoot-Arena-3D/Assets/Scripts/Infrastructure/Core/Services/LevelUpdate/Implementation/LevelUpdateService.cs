using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation
{
    public class LevelUpdateService : ITickable
    {
        private readonly ILevelTimerService _levelTimerService = null;
        private readonly IEnemySpawnService _enemySpawnService = null;

        public LevelUpdateService(
            ILevelTimerService levelTimerService,
            IEnemySpawnService enemySpawnService
            )
        {
            _levelTimerService = levelTimerService;
            _enemySpawnService = enemySpawnService;
        }
        
        public void Tick()
        {
            _levelTimerService.Tick();
            
            _enemySpawnService.Tick();
        }
    }
}