using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Enemies.Model;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class PlayerBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Vector3, IMemoryPool>
    {
        [Inject]
        public void Construct(IBulletRuntimeData runtimeData)
        {
            bulletRuntimeData = runtimeData as BulletRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Vector3 direction, IMemoryPool memoryPool)
        {
            bulletConfiguration = config;
            bulletPool = memoryPool;
            
            SubscribeEvents();
            SetUpBullet(spawnPos, direction);
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
            
            damageTarget.ReceiveDamage(bulletConfiguration.BulletDamage);
            DestroyBullet();
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