using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public class MeleeEnemy : BaseEnemy
    {
        [Inject]
        public void Construct(IEnemyConfigurationData configurationData)
        {
            ConfigurationData = configurationData;
        }
        
        public class Factory : PlaceholderFactory<IEnemyConfigurationData, MeleeEnemy>
        {
        }
    }
}