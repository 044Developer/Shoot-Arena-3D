using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Services.Factory;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.EnemySpawn
{
    public class EnemySpawnService : IEnemySpawnService
    {
        private readonly LevelSessionData _levelSessionData = null;
        private readonly ISpawnPositionService _spawnPositionService = null;
        private readonly IEnemyFactoryService _enemyFactoryService = null;

        private Queue<IEnemy> _meleeEnemyPool = null;
        private Queue<IEnemy> _rangeEnemyPool = null;

        public EnemySpawnService(
            LevelSessionData levelSessionData,
            ISpawnPositionService spawnPositionService,
            IEnemyFactoryService enemyFactoryService
            )
        {
            _levelSessionData = levelSessionData;
            _spawnPositionService = spawnPositionService;
            _enemyFactoryService = enemyFactoryService;
        }

        public void SetUp()
        {
            _meleeEnemyPool = new Queue<IEnemy>(5);
            _rangeEnemyPool = new Queue<IEnemy>(5);
        }

        public void Tick()
        {
            if (_levelSessionData.IsLevelPaused)
                return;

            if (_levelSessionData.TimeToNextRespawn > 0)
                return;
            
            ActivateNewEnemies();
            UpdateSpawnRate();
        }
        
        /*
         *  Enemies Spawn
         */

        private void SpawnNewEnemies(EnemyType type, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var tempEnemy = _enemyFactoryService.SpawnEnemy(type);
                CacheEnemyToPool(tempEnemy);
            }
        }

        private void CacheEnemyToPool(IEnemy enemy)   
        {
            switch (enemy.ConfigurationData.EnemyType)
            {
                case EnemyType.MeleeEnemy:
                    _meleeEnemyPool.Enqueue(enemy);
                    break;
                case EnemyType.RangeEnemy:
                    _rangeEnemyPool.Enqueue(enemy);
                    break;
                case EnemyType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemy.ConfigurationData.EnemyType), enemy.ConfigurationData.EnemyType, null);
            }
        }

        /*
         * Enemies Activate
         */

        private void ActivateNewEnemies()
        {
            if ((_levelSessionData.LevelConfigurationData.EnemyTypes & EnemyType.MeleeEnemy) == EnemyType.MeleeEnemy)
            {
                ActivateMeleeEnemy();
            }
            
            if ((_levelSessionData.LevelConfigurationData.EnemyTypes & EnemyType.RangeEnemy) == EnemyType.RangeEnemy)
            {
                ActivateRangeEnemy();
            }
        }

        private void ActivateMeleeEnemy()
        {
            int neededSpawnCount = NeedToRespawn(EnemyType.MeleeEnemy);

            if (_meleeEnemyPool.Count < neededSpawnCount)
            {
                SpawnNewEnemies(EnemyType.MeleeEnemy, neededSpawnCount);
            }

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = _spawnPositionService.GetEnemySpawnPosition();
                IEnemy tempEnemy = _meleeEnemyPool.Dequeue();
                tempEnemy.SetPosition(tempPos);
                tempEnemy.ActivateEnemy();
            }
        }

        private void ActivateRangeEnemy()
        {
            int neededSpawnCount = NeedToRespawn(EnemyType.RangeEnemy);

            if (_rangeEnemyPool.Count < neededSpawnCount)
            {
                SpawnNewEnemies(EnemyType.RangeEnemy, neededSpawnCount);
            }

            for (int index = 0; index < neededSpawnCount; index++)
            {
                Vector3 tempPos = _spawnPositionService.GetEnemySpawnPosition();
                IEnemy tempEnemy = _rangeEnemyPool.Dequeue();
                tempEnemy.SetPosition(tempPos);
                tempEnemy.ActivateEnemy();
            }
        }
        
        /*
         * Helpers
         */
        
        private int NeedToRespawn(EnemyType type)
        {
            int currentActiveEnemies = 0;
            int enemiesCountToRespawn = 0;
            bool isRespawnRateAggressive = _levelSessionData.CurrentRespawnRate <=
                                           _levelSessionData.LevelConfigurationData.MinRespawnRate;
            
            switch (type)
            {
                case EnemyType.MeleeEnemy:
                    currentActiveEnemies = _levelSessionData.TotalActiveMeleeEnemiesCount;

                    if (isRespawnRateAggressive)
                    {
                        enemiesCountToRespawn = _levelSessionData.LevelConfigurationData.MeleeCountAtLevelValue;
                    }
                    else
                    {
                        enemiesCountToRespawn = _levelSessionData.LevelConfigurationData.MeleeCountAtLevelValue -
                                                currentActiveEnemies;
                    }
                    
                    return enemiesCountToRespawn;
                case EnemyType.RangeEnemy:
                    currentActiveEnemies = _levelSessionData.TotalActiveRangeEnemiesCount;
                    
                    if (isRespawnRateAggressive)
                    {
                        enemiesCountToRespawn = _levelSessionData.LevelConfigurationData.RangeCountAtLevelValue;
                    }
                    else
                    {
                        enemiesCountToRespawn = _levelSessionData.LevelConfigurationData.RangeCountAtLevelValue -
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
            if (_levelSessionData.CurrentRespawnRate > _levelSessionData.LevelConfigurationData.MinRespawnRate)
            {
                _levelSessionData.CurrentRespawnRate -= _levelSessionData.LevelConfigurationData.SpawnDecreaseStep;
            }

            _levelSessionData.TimeToNextRespawn = _levelSessionData.CurrentRespawnRate;
        }
    }
}