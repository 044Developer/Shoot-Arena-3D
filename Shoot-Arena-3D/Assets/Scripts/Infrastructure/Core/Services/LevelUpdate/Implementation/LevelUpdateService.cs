using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using ShootArena.Infrastructure.Core.Services.OutOfBounds;
using ShootArena.Infrastructure.Core.Services.PlayerControl;
using ShootArena.Infrastructure.Core.Services.PlayerShoot;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation
{
    public class LevelUpdateService : ITickable
    {
        private readonly ILevelTimerService _levelTimerService = null;
        private readonly IEnemySpawnService _enemySpawnService = null;
        private readonly IPlayerControlService _playerControlService = null;
        private readonly IOutOfBoundsService _outOfBoundsService = null;
        private readonly IPlayerShootService _playerShootService = null;

        public LevelUpdateService(
            ILevelTimerService levelTimerService,
            IEnemySpawnService enemySpawnService,
            IPlayerControlService playerControlService,
            IOutOfBoundsService outOfBoundsService,
            IPlayerShootService playerShootService
            )
        {
            _levelTimerService = levelTimerService;
            _enemySpawnService = enemySpawnService;
            _playerControlService = playerControlService;
            _outOfBoundsService = outOfBoundsService;
            _playerShootService = playerShootService;
        }
        
        public void Tick()
        {
            _levelTimerService.Tick();
            
            _enemySpawnService.Tick();
            
            _playerControlService.Tick();
            
            _outOfBoundsService.Tick();
            
            _playerShootService.Tick();
        }
    }
}