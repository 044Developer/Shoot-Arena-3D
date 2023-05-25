using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.SpawnPosition.Implementation
{
    public class SpawnPositionService : ISpawnPositionService
    {
        private const float ARENA_BORDER_OFFSET = 1f;
        private const float OBSTACLES_OFFSET = 1f;
        private const float SPAWN_HEIGHT = 1f;
        private const int SPAWN_TRY_COUNT = 100;
        
        private readonly ILevelAreaRuntimeData _levelAreaRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;

        public SpawnPositionService(
            ILevelAreaRuntimeData levelAreaRuntimeData,
            IPlayerRuntimeData playerRuntimeData,
            IEnemyRegistryService enemyRegistryService
            )
        {
            _levelAreaRuntimeData = levelAreaRuntimeData;
            _playerRuntimeData = playerRuntimeData;
            _enemyRegistryService = enemyRegistryService;
        }
        
        /*
         * Public
         */
        
        public Vector3 GetEnemySpawnPosition()
        {
            List<Vector3> obstaclesList = GetEnemyObstaclesListToAvoid();
            return CalculateRandomPositionAvoidingObstacles(obstaclesList);
        }

        public Vector3 GetPlayerSpawnPosition()
        {
            List<Vector3> obstaclesList = GetPlayerObstaclesListToAvoid();
            return CalculateRandomPositionAvoidingObstacles(obstaclesList);
        }
        
        /*
         * Private
         */

        private Vector3 CalculateRandomPositionWithinArena()
        {
            float arenaRadius = GetArenaRadius() - ARENA_BORDER_OFFSET;

            float randomXPos = Random.Range(-arenaRadius, arenaRadius);
            float randomZPos = Random.Range(-arenaRadius, arenaRadius);

            return  new Vector3(randomXPos, SPAWN_HEIGHT, randomZPos);
        }

        private Vector3 CalculateRandomPositionAvoidingObstacles(List<Vector3> obstaclesList)
        {
            float arenaRadius = GetArenaRadius() - ARENA_BORDER_OFFSET;
            Vector3 result = new Vector3();

            for (int tryIndex = 0; tryIndex < SPAWN_TRY_COUNT; tryIndex++)
            {
                float randomXPos = Random.Range(-arenaRadius, arenaRadius);
                float randomZPos = Random.Range(-arenaRadius, arenaRadius);

                result =  new Vector3(randomXPos, SPAWN_HEIGHT, randomZPos);
                
                if (IsPositionFarFromObstacles(result, obstaclesList))
                {
                    return result;
                }
            }
            return result;
        }

        private List<Vector3> GetPlayerObstaclesListToAvoid()
        {
            List<Vector3> result = new List<Vector3>();

            foreach (Transform obst in _levelAreaRuntimeData.Arena.ArenaObstacles)
            {
                result.Add(obst.localPosition);
            }
            
            foreach (IEnemy enemy in _enemyRegistryService.AllEnemies)
            {
                result.Add(enemy.EnemyView.EnemyTransform.localPosition);
            }

            return result;
        }

        private List<Vector3> GetEnemyObstaclesListToAvoid()
        {
            List<Vector3> result = new List<Vector3>();

            foreach (Transform obst in _levelAreaRuntimeData.Arena.ArenaObstacles)
            {
                result.Add(obst.localPosition);
            }
            
            result.Add(_playerRuntimeData.Player.View.Transform.localPosition);

            return result;
        }

        private float GetArenaRadius()
        {
            Bounds bounds = _levelAreaRuntimeData.Arena.MeshCollider.bounds;
            float radius = Mathf.Max(bounds.extents.x, bounds.extents.z);
            return radius;
        }
    
        private bool IsPositionFarFromObstacles(Vector3 position, List<Vector3> obstaclesToAvoid)
        {
            for (int i = 0; i < obstaclesToAvoid.Count; i++)
            {
                if (Vector3.Distance(position, obstaclesToAvoid[i]) < OBSTACLES_OFFSET)
                {
                    return false;
                }
            }
    
            return true;
        }
    }
}