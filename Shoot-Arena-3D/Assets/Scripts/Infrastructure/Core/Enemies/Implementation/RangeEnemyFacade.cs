using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class RangeEnemyFacade : BaseEnemy, IPoolable<IEnemyConfigurationData, Vector3, Transform, IMemoryPool>
    {
        private IEnemyRegistryService _enemyRegistryService = null;
        private IEnemyStateHandler _enemyStateHandler = null;
        
        [Inject]
        public void Construct(
            IEnemyRuntimeData enemyRuntimeData,
            IEnemyRegistryService enemyRegistryService,
            IEnemyStateHandler enemyStateHandler
            )
        {
            EnemyRuntimeData = enemyRuntimeData;
            _enemyRegistryService = enemyRegistryService;
            _enemyStateHandler = enemyStateHandler;
        }

        public void OnSpawned(IEnemyConfigurationData configurationData, Vector3 spawnPosition, Transform parent, IMemoryPool memoryPool)
        {
            ConfigurationData = configurationData;
            MemoryPool = memoryPool;
            
            SetUpEnemy(spawnPosition, parent);
            
            _enemyRegistryService.AddEnemy(this);
            
            _enemyStateHandler.EnterState<EnemyIdleState>();
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
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, Vector3, Transform, RangeEnemyFacade>
        {
        }
    }
}