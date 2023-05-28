using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletRicochet;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerRestore;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class PlayerBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Vector3, IMemoryPool>
    {
        private IBulletRicochetHandler _bulletRicochetHandler = null;
        private IPlayerRestoreHandler _playerRestoreHandler = null;
        
        [Inject]
        public void Construct(IBulletRuntimeData runtimeData,
            IPlayerUltHandler playerUltHandler,
            IBulletRicochetHandler bulletRicochetHandler,
            IPlayerRestoreHandler playerRestoreHandler
            )
        {
            bulletRuntimeData = runtimeData as BulletRuntimeData;
            _bulletRicochetHandler = bulletRicochetHandler;
            _playerRestoreHandler = playerRestoreHandler;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Vector3 direction, IMemoryPool memoryPool)
        {
            bulletConfiguration = config;
            bulletPool = memoryPool;
            
            SubscribeEvents();
            SetUpBullet(spawnPos, direction);
            SetUpRicochetBullet();
        }
        
        public void OnDespawned()
        {
            ResetPosition();
            UnSubscribeEvents();
        }

        public override void OnBulletHitAction(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IEnemy damageTarget))
            {
                DestroyBullet();
                return;
            }
            
            if (bulletRuntimeData.DamageData.IsBulletRicochet)
            {
                CheckRicochetBullet(damageTarget);
                return;
            }
            
            damageTarget.ReceiveDamage(bulletConfiguration.BulletDamage);
            DestroyBullet();
        }

        private void CheckRicochetBullet(IEnemy damageTarget)
        {
            if (bulletRuntimeData.DamageData.HasBulletRicocheted)
            {
                _playerRestoreHandler.RestorePlayerStats();
                damageTarget.ReceiveDamage(bulletConfiguration.BulletDamage);
                DestroyBullet();
            }
            else
            {
                _bulletRicochetHandler.CalculateClosestEnemy(damageTarget);
                bulletRuntimeData.DamageData.HasBulletRicocheted = true;
            }
        }

        private void SetUpRicochetBullet()
        {
            bulletRuntimeData.DamageData.IsBulletRicochet = _bulletRicochetHandler.IsRicochetActive();
            bulletRuntimeData.DamageData.HasBulletRicocheted = false;
            bulletRuntimeData.DamageData.NextRicochetTarget = null;
        }

        private void SubscribeEvents()
        {
            View.ObjectCollisionHandler.OnCollisionEnterEvent += OnBulletHitAction;
        }

        private void UnSubscribeEvents()
        {
            View.ObjectCollisionHandler.OnCollisionEnterEvent -= OnBulletHitAction;
        }
        
        public class Factory : PlaceholderFactory<IBulletConfigurationData, Vector3, Vector3, PlayerBulletFacade>
        {
        }
    }
}