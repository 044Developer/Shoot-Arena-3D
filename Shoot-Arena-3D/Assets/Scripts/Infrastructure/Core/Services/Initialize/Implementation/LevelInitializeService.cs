using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Modules.XMLReader;

namespace ShootArena.Infrastructure.Core.Services.Initialize.Implementation
{
    public class LevelInitializeService : ILevelInitializeService
    {
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly IXMLReaderModule _xmlReaderModule = null;

        public LevelInitializeService(
            ILevelConfigDataModel levelConfigDataModel,
            IXMLReaderModule xmlReaderModule
            )
        {
            _levelConfigDataModel = levelConfigDataModel;
            _xmlReaderModule = xmlReaderModule;
        }
        
        public void ReadLevelScenario()
        {
            ReadLevelData();
            ReadArenaConfigurationData();
            ReadPlayerData();
            ReadEnemiesData();
            ReadBulletsData();
        }

        private void ReadLevelData()
        {
            _levelConfigDataModel.LevelConfigurationData = _xmlReaderModule.ReadLevelScenario();
        }

        private void ReadArenaConfigurationData()
        {
            _levelConfigDataModel.ArenaConfigurationData = _xmlReaderModule.ReadArenaScenario();
        }

        private void ReadPlayerData()
        {
            _levelConfigDataModel.PlayerConfigurationData = _xmlReaderModule.ReadPlayerScenario();
        }

        private void ReadEnemiesData()
        {
            _levelConfigDataModel.EnemyConfigurationDataList = _xmlReaderModule.ReadEnemyScenario();
        }

        private void ReadBulletsData()
        {
            _levelConfigDataModel.bulletConfigurationData = _xmlReaderModule.ReadBulletScenario();
        }
    }
}