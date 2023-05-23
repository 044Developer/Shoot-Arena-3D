using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.States;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class RangeEnemyFacade : BaseEnemy
    {
        [Inject]
        public void Construct(IEnemyConfigurationData configurationData, IPlayerRuntimeData playerRuntimeData)
        {
            ConfigurationData = configurationData;
            playerRuntime = playerRuntimeData;
        }

        public override void Attack()
        {
            ChangeState(EnemyStateType.RechargeState);
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, RangeEnemyFacade>
        {
        }
    }
}