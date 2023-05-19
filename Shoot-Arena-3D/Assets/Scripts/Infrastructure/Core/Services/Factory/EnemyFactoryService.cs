using System;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Modules.CustomLogger;

namespace ShootArena.Infrastructure.Core.Services.Factory
{
    public class EnemyFactoryService : IEnemyFactoryService
    {
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly MeleeEnemy.Factory _meleeFactory = null;
        private readonly RangeEnemy.Factory _rangedFactory = null;
        private readonly ICustomLoggerModule _logger = null;

        public EnemyFactoryService(
            ILevelConfigDataModel levelConfigDataModel,
            MeleeEnemy.Factory meleeFactory,
            RangeEnemy.Factory rangedFactory,
            ICustomLoggerModule logger
            )
        {
            _levelConfigDataModel = levelConfigDataModel;
            _meleeFactory = meleeFactory;
            _rangedFactory = rangedFactory;
            _logger = logger;
        }

        public IEnemy SpawnEnemy(EnemyType type)
        {
            var config = GetCorrectConfig(type);
            switch (type)
            {
                case EnemyType.MeleeEnemy:
                    return _meleeFactory.Create(config);
                case EnemyType.RangeEnemy:
                    return _rangedFactory.Create(config);
                case EnemyType.None:
                default:
                    _logger.LogError("Enemy Factory", $"There is no enemy of type {type}");
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private IEnemyConfigurationData GetCorrectConfig(EnemyType type)
        {
            return _levelConfigDataModel.EnemyConfigurationDataList.Find(config => config.EnemyType == type);
        }
    }
}