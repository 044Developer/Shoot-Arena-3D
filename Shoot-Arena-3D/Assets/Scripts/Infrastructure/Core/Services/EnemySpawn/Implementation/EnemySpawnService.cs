using System;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.EnemySpawn.Implementation
{
    public class EnemySpawnService : IEnemySpawnService
    {
        private readonly ISpawnPositionService _spawnPositionService = null;
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;
        private readonly ILevelEnemiesRuntimeData _enemiesRuntimeData = null;
        private readonly MeleeEnemyFacade.Factory _meleeFactory = null;
        private readonly RangeEnemyFacade.Factory _rangedFactory  = null;
        private readonly ICustomLoggerModule _logger  = null;
        private readonly IDynamicPrefabFacade _dynamicPrefabFacade  = null;

        public EnemySpawnService(
            ISpawnPositionService spawnPositionService,
            ILevelConfigDataModel levelConfigDataModel,
            ILevelTimingRuntimeData levelTimingRuntimeData,
            ILevelEnemiesRuntimeData enemiesRuntimeData,
            MeleeEnemyFacade.Factory meleeFactory,
            RangeEnemyFacade.Factory rangedFactory,
            ICustomLoggerModule logger,
            IDynamicPrefabFacade dynamicPrefabFacade
        )
        {
            _spawnPositionService = spawnPositionService;
            _levelConfigDataModel = levelConfigDataModel;
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _enemiesRuntimeData = enemiesRuntimeData;
            _meleeFactory = meleeFactory;
            _rangedFactory = rangedFactory;
            _logger = logger;
            _dynamicPrefabFacade = dynamicPrefabFacade;
        }

        public void Tick()
        {
            if (_levelTimingRuntimeData.IsLevelPaused)
                return;

            if (_levelTimingRuntimeData.TimeToNextRespawn > 0)
                return;
            
            ActivateNewEnemies();
            UpdateSpawnRate();
        }
        
        /*
         *  Enemies Spawn
         */
        
        private IEnemy SpawnEnemy(EnemyType type)
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

            Transform parent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Enemies);
            tempEnemy.SetParent(parent);
            tempEnemy.Initialize();

            return tempEnemy;
        }

        private IEnemyConfigurationData GetCorrectConfig(EnemyType type)
        {
            return _levelConfigDataModel.EnemyConfigurationDataList.Find(config => config.EnemyType == type);
        }

        /*
         * Enemies Activate
         */

        private void ActivateNewEnemies()
        {
            if ((_levelConfigDataModel.LevelConfigurationData.EnemyTypes & EnemyType.MeleeEnemy) == EnemyType.MeleeEnemy)
            {
                ActivateMeleeEnemy();
            }
            
            if ((_levelConfigDataModel.LevelConfigurationData.EnemyTypes & EnemyType.RangeEnemy) == EnemyType.RangeEnemy)
            {
                ActivateRangeEnemy();
            }
        }

        private void ActivateMeleeEnemy()
        {
            int neededSpawnCount = NeedToRespawn(EnemyType.MeleeEnemy);

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = _spawnPositionService.GetEnemySpawnPosition();
                IEnemy tempEnemy = SpawnEnemy(EnemyType.MeleeEnemy);
                tempEnemy.SetPosition(tempPos);
                tempEnemy.ActivateEnemy();
                _enemiesRuntimeData.AllActiveEnemies.Add(tempEnemy);
            }
        }

        private void ActivateRangeEnemy()
        {
            int neededSpawnCount = NeedToRespawn(EnemyType.RangeEnemy);

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = _spawnPositionService.GetEnemySpawnPosition();
                IEnemy tempEnemy = SpawnEnemy(EnemyType.RangeEnemy);
                tempEnemy.SetPosition(tempPos);
                tempEnemy.ActivateEnemy();
                _enemiesRuntimeData.AllActiveEnemies.Add(tempEnemy);
            }
        }
        
        /*
         * Helpers
         */
        
        private int NeedToRespawn(EnemyType type)
        {
            int currentActiveEnemies = 0;
            int enemiesCountToRespawn = 0;
            bool isRespawnRateAggressive = _levelTimingRuntimeData.CurrentRespawnRate <=
                                           _levelConfigDataModel.LevelConfigurationData.MinRespawnRate;
            
            switch (type)
            {
                case EnemyType.MeleeEnemy:
                    currentActiveEnemies = _enemiesRuntimeData.TotalActiveMeleeEnemiesCount;

                    if (isRespawnRateAggressive)
                    {
                        enemiesCountToRespawn = _levelConfigDataModel.LevelConfigurationData.MeleeCountAtLevelValue;
                    }
                    else
                    {
                        enemiesCountToRespawn = _levelConfigDataModel.LevelConfigurationData.MeleeCountAtLevelValue -
                                                currentActiveEnemies;
                    }
                    
                    return enemiesCountToRespawn;
                case EnemyType.RangeEnemy:
                    currentActiveEnemies = _enemiesRuntimeData.TotalActiveRangeEnemiesCount;
                    
                    if (isRespawnRateAggressive)
                    {
                        enemiesCountToRespawn = _levelConfigDataModel.LevelConfigurationData.RangeCountAtLevelValue;
                    }
                    else
                    {
                        enemiesCountToRespawn = _levelConfigDataModel.LevelConfigurationData.RangeCountAtLevelValue -
                                                currentActiveEnemies;
                    }
                    
                    return enemiesCountToRespawn;
                case EnemyType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void UpdateSpawnRate()
        {
            if (_levelTimingRuntimeData.CurrentRespawnRate > _levelConfigDataModel.LevelConfigurationData.MinRespawnRate)
            {
                _levelTimingRuntimeData.CurrentRespawnRate -= _levelConfigDataModel.LevelConfigurationData.SpawnDecreaseStep;
            }

            _levelTimingRuntimeData.TimeToNextRespawn = _levelTimingRuntimeData.CurrentRespawnRate;
        }
    }
}