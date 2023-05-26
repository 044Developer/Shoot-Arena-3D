using ShootArena.Infrastructure.Core.Player.Handlers.OutOfBounds;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerControl;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerShoot;
using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation
{
    public class LevelUpdateService : ITickable
    {
        private readonly ILevelTimerService _levelTimerService = null;
        private readonly IEnemySpawnService _enemySpawnService = null;
        private readonly IPlayerControlHandler _playerControlHandler = null;
        private readonly IOutOfBoundsHandler _outOfBoundsHandler = null;
        private readonly IPlayerShootHandler _playerShootHandler = null;

        public LevelUpdateService(
            ILevelTimerService levelTimerService,
            IEnemySpawnService enemySpawnService,
            IPlayerControlHandler playerControlHandler,
            IOutOfBoundsHandler outOfBoundsHandler,
            IPlayerShootHandler playerShootHandler
            )
        {
            _levelTimerService = levelTimerService;
            _enemySpawnService = enemySpawnService;
            _playerControlHandler = playerControlHandler;
            _outOfBoundsHandler = outOfBoundsHandler;
            _playerShootHandler = playerShootHandler;
        }
        
        public void Tick()
        {
            _levelTimerService.Tick();
            
            _enemySpawnService.Tick();
            
            _playerControlHandler.Tick();
            
            _outOfBoundsHandler.Tick();
            
            _playerShootHandler.Tick();
        }
    }
}