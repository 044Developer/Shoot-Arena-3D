using System;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsContainer;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsContainer.Data;

namespace ShootArena.Infrastructure.Core.Services.Factory
{
    public class EnemyFactoryService : IEnemyFactoryService
    {
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly MeleeEnemy.Factory _meleeFactory = null;
        private readonly RangeEnemy.Factory _rangedFactory = null;
        private readonly ICustomLoggerModule _logger = null;
        private readonly IDynamicPrefabContainer _dynamicPrefabContainer = null;
        private readonly ILevelEnemiesRuntimeData _enemiesRuntimeData = null;

        public EnemyFactoryService(
            ILevelConfigDataModel levelConfigDataModel,
            MeleeEnemy.Factory meleeFactory,
            RangeEnemy.Factory rangedFactory,
            ICustomLoggerModule logger,
            IDynamicPrefabContainer dynamicPrefabContainer,
            ILevelEnemiesRuntimeData enemiesRuntimeData
            )
        {
            _levelConfigDataModel = levelConfigDataModel;
            _meleeFactory = meleeFactory;
            _rangedFactory = rangedFactory;
            _logger = logger;
            _dynamicPrefabContainer = dynamicPrefabContainer;
            _enemiesRuntimeData = enemiesRuntimeData;
        }

        public IEnemy SpawnEnemy(EnemyType type)
        {
            IEnemyConfigurationData config = GetCorrectConfig(type);
            IEnemy tempEnemy;
            
            switch (type)
            {
                case EnemyType.MeleeEnemy:
                    tempEnemy = _meleeFactory.Create(config);
                    _enemiesRuntimeData.TotalActiveMeleeEnemiesCount++;
                    break;
                case EnemyType.RangeEnemy:
                    tempEnemy = _rangedFactory.Create(config);
                    _enemiesRuntimeData.TotalActiveRangeEnemiesCount++;
                    break;
                case EnemyType.None:
                default:
                    _logger.LogError("Enemy Factory", $"There is no enemy of type {type}");
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            tempEnemy.SetParent(_dynamicPrefabContainer.GetPrefabParent(DynamicPrefabRootType.Enemies));

            return tempEnemy;
        }

        private IEnemyConfigurationData GetCorrectConfig(EnemyType type)
        {
            return _levelConfigDataModel.EnemyConfigurationDataList.Find(config => config.EnemyType == type);
        }
    }
}