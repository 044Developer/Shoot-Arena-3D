using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class PlayerBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, Vector3, IMemoryPool>
    {
        [Inject]
        public void Construct(IBulletRuntimeData bulletRuntimeData)
        {
            runtimeData = bulletRuntimeData as BulletRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, Vector3 direction, IMemoryPool memoryPool)
        {
            ConfigurationData = config;
            runtimeData.BulletDirection = direction;
            SetSpawnPoint(spawnPos);
            MemoryPool = memoryPool;
        }
        
        public void OnDespawned()
        {
        }
        
        public class Factory : PlaceholderFactory<IBulletConfigurationData, Vector3, Vector3, PlayerBulletFacade>
        {
        }
    }
}