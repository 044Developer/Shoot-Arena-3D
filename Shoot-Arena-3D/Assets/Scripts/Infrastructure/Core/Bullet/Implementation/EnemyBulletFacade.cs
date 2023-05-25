using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class EnemyBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Transform, IMemoryPool>
    {
        private BulletRuntimeData _bulletRuntimeData = null;
        
        [Inject]
        public void Construct(IBulletRuntimeData bulletRuntimeData)
        {
            _bulletRuntimeData = bulletRuntimeData as BulletRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Transform target, IMemoryPool memoryPool)
        {
            SubscribeEvents();
            
            ConfigurationData = config;
            _bulletRuntimeData.Bullet = this;
            _bulletRuntimeData.BulletTarget = target;
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
        
        public class Factory : PlaceholderFactory<IBulletConfigurationData, Vector3, Transform, EnemyBulletFacade>
        {
        }
    }
}