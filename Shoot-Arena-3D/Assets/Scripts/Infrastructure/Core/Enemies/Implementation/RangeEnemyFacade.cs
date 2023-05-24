using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Services.EnemyDie;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.Core.Services.EnemyState;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class RangeEnemyFacade : BaseEnemy, IPoolable<IEnemyConfigurationData, Vector3, Transform, IMemoryPool>
    {
        private IEnemyRegistryService _enemyRegistryService = null;
        private IEnemyDieService _enemyDieService = null;
        private IEnemyStateService _enemyStateService = null;
        
        [Inject]
        public void Construct(
            IEnemyRegistryService enemyRegistryService,
            IEnemyDieService enemyDieService,
            IEnemyStateService enemyStateService
            )
        {
            _enemyRegistryService = enemyRegistryService;
            _enemyDieService = enemyDieService;
            _enemyStateService = enemyStateService;
        }

        public override void Die()
        {
            _enemyDieService.Die();
            MemoryPool.Despawn(this);
        }

        public void OnSpawned(IEnemyConfigurationData configurationData, Vector3 spawnPosition, Transform parent, IMemoryPool memoryPool)
        {
            ConfigurationData = configurationData;
            MemoryPool = memoryPool;
            
            SetUpEnemy(spawnPosition, parent);
            
            _enemyRegistryService.AddEnemy(this);
        }

        public void OnDespawned()
        {
            DisposeEnemy();
            
            _enemyRegistryService.RemoveEnemy(this);
            MemoryPool = null;
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, Vector3, Transform, RangeEnemyFacade>
        {
        }
    }
}