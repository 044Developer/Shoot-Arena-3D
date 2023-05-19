using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Player.Data.Configuration;

namespace ShootArena.Infrastructure.Modules.XMLReader
{
    public interface IXMLReaderModule
    {
        ILevelConfigurationData ReadLevelScenario();
        IPlayerConfigurationData ReadPlayerScenario();
        IEnemyConfigurationData ReadEnemyScenario();
    }
}