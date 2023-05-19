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
            //ReadPlayerData();
            ReadEnemiesData();
        }

        private void ReadLevelData()
        {
            _levelConfigDataModel.LevelConfigurationData = _xmlReaderModule.ReadLevelScenario();
        }

        private void ReadPlayerData()
        {
            _levelConfigDataModel.PlayerConfigurationData = _xmlReaderModule.ReadPlayerScenario();
        }

        private void ReadEnemiesData()
        {
            _levelConfigDataModel.EnemyConfigurationDataList = _xmlReaderModule.ReadEnemyScenario();
        }
    }
}