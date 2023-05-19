using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Model;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Implementation
{
    public class MeleeEnemyFacade : BaseEnemy
    {
        [Inject]
        public void Construct(IEnemyConfigurationData configurationData)
        {
            ConfigurationData = configurationData;
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, MeleeEnemyFacade>
        {
        }
    }
}