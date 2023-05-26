using ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.BulletSpawn;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerShoot.Implementation
{
    public class PlayerShootHandler : IPlayerShootHandler
    {
        private readonly IBulletSpawnService _bulletSpawnService = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerInputHandler _inputHandler = null;

        public PlayerShootHandler
        (
            IPlayerMobileInputHandler mobileInputHandler,
            IPlayerStandaloneInputHandler standaloneInputHandler,
            IDeviceCheckModule deviceCheckModule,
            IBulletSpawnService bulletSpawnService,
            IPlayerRuntimeData playerRuntimeData
        )
        {
            _bulletSpawnService = bulletSpawnService;
            _playerRuntimeData = playerRuntimeData;

            if (deviceCheckModule.CurrentDeviceType.HasFlag(CurrentDeviceType.Mobile))
                _inputHandler = mobileInputHandler;
            else
                _inputHandler = standaloneInputHandler;
        }
        
        public void Tick()
        {
            if (_inputHandler.IsAttackButtonUp())
            {
                Shoot();       
            }

            if (_inputHandler.IsUltButtonUp())
            {
                Ult();
            }
        }

        private void Shoot()
        {
            _bulletSpawnService.SpawnPlayerBullet(_playerRuntimeData.Player.View.ShootPoint.position, _playerRuntimeData.Player.View.ShootPoint.forward);
        }

        private void Ult()
        {
            
        }
    }
}