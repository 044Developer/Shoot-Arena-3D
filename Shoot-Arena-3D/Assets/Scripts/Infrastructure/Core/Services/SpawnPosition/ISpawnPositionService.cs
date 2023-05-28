using System.Collections.Generic;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.SpawnPosition
{
    public interface ISpawnPositionService
    {
        void Initialize();
        Vector3 GetFarSpawnPosition(List<Transform> obstaclePositions);
        Vector3 GetSpawnPositionFromNewArea();
        List<Vector3> GetMultipleSpawnPositionsFromNewArea(int count, float positionOffset);
    }
}