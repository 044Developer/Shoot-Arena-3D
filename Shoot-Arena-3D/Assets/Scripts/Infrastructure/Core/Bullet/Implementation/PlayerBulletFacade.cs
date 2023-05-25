using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class PlayerBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Vector3, IMemoryPool>
    {
        private BulletRuntimeData _bulletRuntimeData = null;
        
        [Inject]
        public void Construct(IBulletRuntimeData bulletRuntimeData)
        {
            _bulletRuntimeData = bulletRuntimeData as BulletRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Vector3 direction, IMemoryPool memoryPool)
        {
            SubscribeEvents();
            
            ConfigurationData = config;
            _bulletRuntimeData.Bullet = this;
            _bulletRuntimeData.BulletDirection = direction;
            _bulletRuntimeData.SpawnStartTime = Time.realtimeSinceStartup;
            SetSpawnPoint(spawnPos);
            MemoryPool = memoryPool;
        }
        
        public void OnDespawned()
        {
            UnSubscribeEvents();
        }

        public override void OnBulletHitAction(Collision collision)
        {
            MemoryPool.Despawn(this);
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