using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Implementation;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
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
        private readonly MeleeEnemyFacade.Factory _meleeFactory = null;
        private readonly RangeEnemyFacade.Factory _rangedFactory  = null;
        private readonly ICustomLoggerModule _logger  = null;
        private readonly IDynamicPrefabFacade _dynamicPrefabFacade  = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;

        public EnemySpawnService(
            ISpawnPositionService spawnPositionService,
            ILevelConfigDataModel levelConfigDataModel,
            ILevelTimingRuntimeData levelTimingRuntimeData,
            MeleeEnemyFacade.Factory meleeFactory,
            RangeEnemyFacade.Factory rangedFactory,
            ICustomLoggerModule logger,
            IDynamicPrefabFacade dynamicPrefabFacade,
            IEnemyRegistryService enemyRegistryService
        )
        {
            _spawnPositionService = spawnPositionService;
            _levelConfigDataModel = levelConfigDataModel;
            _levelTimingRuntimeData = levelTimingRuntimeData;
            _meleeFactory = meleeFactory;
            _rangedFactory = rangedFactory;
            _logger = logger;
            _dynamicPrefabFacade = dynamicPrefabFacade;
            _enemyRegistryService = enemyRegistryService;
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
        
        private void SpawnEnemy(EnemyType type, Vector3 spawnPosition)
        {
            IEnemyConfigurationData config = GetCorrectConfig(type);
            Transform parent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Enemies);
            
            switch (type)
            {
                case EnemyType.MeleeEnemy:
                    _meleeFactory.Create(config, spawnPosition, parent);
                    break;
                case EnemyType.RangeEnemy:
                    _rangedFactory.Create(config, spawnPosition, parent);
                    break;
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

            if (neededSpawnCount <= 0)
                return;

            List<Vector3> spawnPositions = _spawnPositionService.GetMultipleSpawnPositionsFromNewArea(neededSpawnCount, 2f);

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = spawnPositions[index];
                SpawnEnemy(EnemyType.MeleeEnemy, tempPos);
            }
        }

        private void ActivateRangeEnemy()
        {
            int neededSpawnCount = NeedToRespawn(EnemyType.RangeEnemy);

            if (neededSpawnCount <= 0)
                return;

            List<Vector3> spawnPositions = _spawnPositionService.GetMultipleSpawnPositionsFromNewArea(neededSpawnCount, 2f);

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = spawnPositions[index];
                SpawnEnemy(EnemyType.RangeEnemy, tempPos);
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
                    currentActiveEnemies = _enemyRegistryService.TotalMeleeCount;

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
                    currentActiveEnemies = _enemyRegistryService.TotalRangedCount;
                    
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