using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.Core.Services.EnemyState;
using ShootArena.Infrastructure.Core.Services.EnemyState.States;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class MeleeEnemyFacade : BaseEnemy, IPoolable<IEnemyConfigurationData, Vector3, Transform, IMemoryPool>
    {
        private IEnemyRegistryService _enemyRegistryService = null;
        private IEnemyStateService _enemyStateService = null;
        
        [Inject]
        public void Construct(
            IEnemyRegistryService enemyRegistryService,
            IEnemyStateService enemyStateService
            )
        {
            _enemyRegistryService = enemyRegistryService;
            _enemyStateService = enemyStateService;
        }
        
        public void OnSpawned(IEnemyConfigurationData configurationData, Vector3 spawnPosition, Transform parent, IMemoryPool memoryPool)
        {
            ConfigurationData = configurationData;
            MemoryPool = memoryPool;
            
            SetUpEnemy(spawnPosition, parent);

            _enemyRegistryService.AddEnemy(this);
            
            _enemyStateService.RegisterService(EnemyRuntimeData);
            _enemyStateService.EnterState<EnemySearchState>();
        }

        public void OnDespawned()
        {
            DisposeEnemy();
            
            _enemyRegistryService.RemoveEnemy(this);
            MemoryPool = null;
        }

        public override void Die()
        {
            MemoryPool.Despawn(this);
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, Vector3, Transform, MeleeEnemyFacade>
        {
        }
    }
}