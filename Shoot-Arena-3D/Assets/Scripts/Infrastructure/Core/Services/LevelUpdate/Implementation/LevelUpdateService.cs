using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using ShootArena.Infrastructure.Core.Services.PlayerControl;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation
{
    public class LevelUpdateService : ITickable
    {
        private readonly ILevelTimerService _levelTimerService = null;
        private readonly IEnemySpawnService _enemySpawnService = null;
        private readonly IPlayerControlService _playerControlService = null;

        public LevelUpdateService(
            ILevelTimerService levelTimerService,
            IEnemySpawnService enemySpawnService,
            IPlayerControlService playerControlService
            )
        {
            _levelTimerService = levelTimerService;
            _enemySpawnService = enemySpawnService;
            _playerControlService = playerControlService;
        }
        
        public void Tick()
        {
            _levelTimerService.Tick();
            
            _enemySpawnService.Tick();
            
            _playerControlService.Tick();
        }
    }
}