using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.BulletSpawn;
using ShootArena.Infrastructure.Core.Services.PlayerInput;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;

namespace ShootArena.Infrastructure.Core.Services.PlayerShoot.Implementation
{
    public class PlayerShootService : IPlayerShootService
    {
        private readonly IBulletSpawnService _bulletSpawnService = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerInputService _inputService = null;

        public PlayerShootService
        (
            IPlayerMobileInputService mobileInputService,
            IPlayerStandaloneInputService standaloneInputService,
            IDeviceCheckModule deviceCheckModule,
            IBulletSpawnService bulletSpawnService,
            IPlayerRuntimeData playerRuntimeData
        )
        {
            _bulletSpawnService = bulletSpawnService;
            _playerRuntimeData = playerRuntimeData;

            if (deviceCheckModule.CurrentDeviceType.HasFlag(CurrentDeviceType.Mobile))
                _inputService = mobileInputService;
            else
                _inputService = standaloneInputService;
        }
        
        public void Tick()
        {
            if (_inputService.IsAttackButtonUp())
            {
                Shoot();       
            }

            if (_inputService.IsUltButtonUp())
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