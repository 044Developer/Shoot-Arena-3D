using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea;
using ShootArena.Infrastructure.Modules.CustomLogger;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.SpawnPosition.Implementation
{
    public class SpawnPositionService : ISpawnPositionService
    {
        private const float FULL_ARENA_ANGLE = 360f;
        private const float SPAWN_POS_HEIGHT = 1f;
        
        private readonly ILevelAreaRuntimeData _levelAreaRuntimeData = null;
        private readonly ICustomLoggerModule _loggerModule = null;
        private readonly ILevelConfigDataModel _levelConfigDataModel;

        private float _arenaRadius = 0f;
        private int _numberOfSplittedAreas = 0;
        private float _offsetFromObstacle = 0f;
        private List<Transform> _cachedArenaObstacles = null;
        private List<Vector2> _cachedArenaSpawnAreas = null;
        private int _currentSpawningArea = 0;

        public SpawnPositionService(
            ILevelAreaRuntimeData levelAreaRuntimeData,
            ICustomLoggerModule loggerModule,
            ILevelConfigDataModel levelConfigDataModel
            )
        {
            _levelAreaRuntimeData = levelAreaRuntimeData;
            _loggerModule = loggerModule;
            _levelConfigDataModel = levelConfigDataModel;
        }

        public void Initialize()
        {
            _numberOfSplittedAreas = _levelConfigDataModel.ArenaConfigurationData.NumberOfArenaAreas;
            _offsetFromObstacle = _levelConfigDataModel.ArenaConfigurationData.OffsetFromClosestObstacle;
            _arenaRadius = GetArenaRadius();
            _cachedArenaObstacles = _levelAreaRuntimeData.Arena.ArenaView.ArenaObstacles;
            _cachedArenaSpawnAreas = GenerateSmallAreas();
        }

        public Vector3 GetFarSpawnPosition(List<Transform> obstaclePositions)
        {
            Vector2 farthestPoint = Vector2.zero;
            float farthestDistance = 0f;

            foreach (Vector2 smallArea in _cachedArenaSpawnAreas)
            {
                Vector2 randomPosition = Random.insideUnitCircle * (_arenaRadius / _numberOfSplittedAreas) + smallArea;

                float minDistance = Mathf.Infinity;

                foreach (Transform obstacle in obstaclePositions)
                {
                    float distance = Vector2.Distance(randomPosition,
                        new Vector2(obstacle.position.x, obstacle.position.z));

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }

                if (minDistance > farthestDistance)
                {
                    farthestDistance = minDistance;
                    farthestPoint = randomPosition;
                }
            }

            Vector3 spawnPosition = new Vector3(farthestPoint.x, 0f, farthestPoint.y);
            if (obstaclePositions.Count > 0)
            {
                Vector3 obstacleDirection = (spawnPosition - obstaclePositions[0].position).normalized;
                spawnPosition += obstacleDirection * _offsetFromObstacle;
            }

            spawnPosition = ClampPositionWithinArea(spawnPosition);
            spawnPosition.y = SPAWN_POS_HEIGHT;

            return spawnPosition;
        }

        public Vector3 GetSpawnPositionFromNewArea()
        {
            GenerateNextSpawnArea();
            
            if (_currentSpawningArea < 0 || _currentSpawningArea >= _cachedArenaSpawnAreas.Count)
            {
                _loggerModule.LogWarning("Arena Spawner", "Invalid area index.");
                return Vector3.zero;
            }

            Vector2 selectedArea = _cachedArenaSpawnAreas[_currentSpawningArea];

            Vector2 randomPosition = Random.insideUnitCircle * (_arenaRadius / _numberOfSplittedAreas) + selectedArea;

            Transform closestObstacle = FindClosestObstacle(randomPosition);

            Vector3 spawnPosition = new Vector3(randomPosition.x, 0f, randomPosition.y);
            Vector3 obstacleDirection = (spawnPosition - closestObstacle.position).normalized;
            spawnPosition += obstacleDirection * _offsetFromObstacle;

            spawnPosition = ClampPositionWithinArea(spawnPosition);

            spawnPosition.y = SPAWN_POS_HEIGHT;
            
            return spawnPosition;
        }
        
        public List<Vector3> GetMultipleSpawnPositionsFromNewArea(int count, float positionOffset)
        {
            GenerateNextSpawnArea();
            
            if (_currentSpawningArea < 0 || _currentSpawningArea >= _cachedArenaSpawnAreas.Count)
            {
                _loggerModule.LogWarning("Arena Spawner","Invalid area index.");
                return null;
            }

            if (count <= 0)
            {
                _loggerModule.LogWarning("Arena Spawner","Invalid count.");
                return null;
            }

            List<Vector3> spawnPositions = new List<Vector3>();

            Vector2 selectedArea = _cachedArenaSpawnAreas[_currentSpawningArea];

            for (int i = 0; i < count; i++)
            {
                float angle = i * (360f / count);
                Vector2 offsetPosition = selectedArea + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * positionOffset;

                Transform closestObstacle = FindClosestObstacle(offsetPosition);

                Vector3 spawnPosition = new Vector3(offsetPosition.x, 0f, offsetPosition.y);
                Vector3 obstacleDirection = (spawnPosition - closestObstacle.position).normalized;
                spawnPosition += obstacleDirection * _offsetFromObstacle;

                spawnPosition = ClampPositionWithinArea(spawnPosition);

                spawnPosition.y = SPAWN_POS_HEIGHT;
                
                spawnPositions.Add(spawnPosition);
            }

            return spawnPositions;
        }
        
        private float GetArenaRadius()
        {
            Bounds bounds = _levelAreaRuntimeData.Arena.ArenaView.MeshCollider.bounds;
            float radius = Mathf.Max(bounds.extents.x, bounds.extents.z);
            return radius;
        }
        
        private List<Vector2> GenerateSmallAreas()
        {
            List<Vector2> smallAreas = new List<Vector2>();

            for (int i = 0; i < _numberOfSplittedAreas; i++)
            {
                float angle = i * (FULL_ARENA_ANGLE / _numberOfSplittedAreas);
                var arenaPosition = _levelAreaRuntimeData.Arena.ArenaView.ArenaTransform.position;
                Vector2 smallAreaCenter = new Vector2(
                    arenaPosition.x + _arenaRadius * Mathf.Cos(angle * Mathf.Deg2Rad),
                    arenaPosition.z + _arenaRadius * Mathf.Sin(angle * Mathf.Deg2Rad)
                );

                smallAreas.Add(smallAreaCenter);
            }

            return smallAreas;
        }

        private Transform FindClosestObstacle(Vector2 position)
        {
            Transform closestObstacle = null;
            float closestDistance = Mathf.Infinity;

            foreach (Transform obstacle in _cachedArenaObstacles)
            {
                float distance = Vector2.Distance(position, new Vector2(obstacle.position.x, obstacle.position.z));

                if (distance < closestDistance)
                {
                    closestObstacle = obstacle;
                    closestDistance = distance;
                }
            }

            return closestObstacle;
        }

        private Vector3 ClampPositionWithinArea(Vector3 position)
        {
            Vector3 center = _levelAreaRuntimeData.Arena.ArenaView.ArenaTransform.position;
            Vector3 direction = position - center;
            float distanceFromCenter = direction.magnitude;
            float maxDistance = _arenaRadius - _offsetFromObstacle;

            if (distanceFromCenter > maxDistance)
            {
                direction = direction.normalized * maxDistance;
                position = center + direction;
            }

            return position;
        }

        private void GenerateNextSpawnArea()
        {
            int spawnAreaCounts = _cachedArenaSpawnAreas.Count;
            
            if (_currentSpawningArea < spawnAreaCounts - 1)
            {
                _currentSpawningArea++;
            }
            else
            {
                _currentSpawningArea = 0;
            }
        }
    }
}