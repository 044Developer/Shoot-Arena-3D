using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.States;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class MeleeEnemyFacade : BaseEnemy, IPoolable<IEnemyConfigurationData, IMemoryPool>
    {
        [Inject]
        public void Construct(IPlayerRuntimeData playerRuntimeData)
        {
            playerRuntime = playerRuntimeData;
        }

        public override void Attack()
        {
            ChangeState(EnemyStateType.DieState);
        }

        public void OnSpawned(IEnemyConfigurationData configurationData, IMemoryPool memoryPool)
        {
            ConfigurationData = configurationData;
            MemoryPool = memoryPool;
        }

        public void OnDespawned()
        {
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, MeleeEnemyFacade>
        {
        }
    }
}