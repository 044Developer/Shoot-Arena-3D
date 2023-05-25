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
            runtimeData = enemyRuntimeData  as EnemyRuntimeData;
            _enemyRegistryService = enemyRegistryService;
            _enemyStateHandler = enemyStateHandler;
        }

        public void OnSpawned(IEnemyConfigurationData configurationData, Vector3 spawnPosition, Transform parent, IMemoryPool memoryPool)
        {
            enemyConfiguration = configurationData;
            enemyPool = memoryPool;
            
            SetUpEnemy(spawnPosition, parent);
            
            _enemyRegistryService.AddEnemy(this);
            
            _enemyStateHandler.EnterState<EnemyIdleState>();
        }

        public void OnDespawned()
        {
            DisposeEnemy();
            
            _enemyRegistryService.RemoveEnemy(this);
            enemyPool = null;
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, Vector3, Transform, RangeEnemyFacade>
        {
        }
    }
}