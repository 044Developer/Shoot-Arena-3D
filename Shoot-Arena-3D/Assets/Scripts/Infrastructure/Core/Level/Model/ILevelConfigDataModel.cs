using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Player.Data.Configuration;

namespace ShootArena.Infrastructure.Core.Level.Model
{
    public interface ILevelConfigDataModel
    {
        IPlayerConfigurationData PlayerConfigurationData { get; set; } 
        List<IEnemyConfigurationData> EnemyConfigurationDataList { get; set; }
        ILevelConfigurationData LevelConfigurationData { get; set; } 
        List<IBulletConfigurationData> bulletConfigurationData { get; set; }
    }
}