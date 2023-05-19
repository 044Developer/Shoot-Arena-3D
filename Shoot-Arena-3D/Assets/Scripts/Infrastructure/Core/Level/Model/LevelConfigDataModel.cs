using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Player.Data.Configuration;

namespace ShootArena.Infrastructure.Core.Level.Model
{
    public class LevelConfigDataModel : ILevelConfigDataModel
    {
        public IPlayerConfigurationData PlayerConfigurationData { get; set; }
        public IEnemyConfigurationData EnemyConfigurationData { get; set; }
        public ILevelConfigurationData LevelConfigurationData { get; set; }
    }
}