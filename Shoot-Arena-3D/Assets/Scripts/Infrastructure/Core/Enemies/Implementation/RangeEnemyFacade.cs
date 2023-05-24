using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.States;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class RangeEnemyFacade : BaseEnemy, IPoolable<IEnemyConfigurationData, IMemoryPool>
    {
        [Inject]
        public void Construct(IPlayerRuntimeData playerRuntimeData)
        {
            playerRuntime = playerRuntimeData;
        }

        public override void Attack()
        {
            ChangeState(EnemyStateType.RechargeState);
        }

        public void OnSpawned(IEnemyConfigurationData configurationData, IMemoryPool memoryPool)
        {
            ConfigurationData = configurationData;
            MemoryPool = memoryPool;
        }

        public void OnDespawned()
        {
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, RangeEnemyFacade>
        {
        }
    }
}