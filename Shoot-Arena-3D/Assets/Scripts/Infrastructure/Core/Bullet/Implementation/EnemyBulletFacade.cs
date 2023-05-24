using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class EnemyBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Transform, IMemoryPool>
    {
        [Inject]
        public void Construct(IBulletRuntimeData bulletRuntimeData)
        {
            runtimeData = bulletRuntimeData as BulletRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Transform target, IMemoryPool memoryPool)
        {
            ConfigurationData = config;
            runtimeData.Bullet = this;
            runtimeData.BulletTarget = target;
            runtimeData.SpawnStartTime = Time.realtimeSinceStartup;
            SetSpawnPoint(spawnPos);
            MemoryPool = memoryPool;
        }
        
        public void OnDespawned()
        {
        }
        
        public class Factory : PlaceholderFactory<IBulletConfigurationData, Vector3, Transform, EnemyBulletFacade>
        {
        }
    }
}