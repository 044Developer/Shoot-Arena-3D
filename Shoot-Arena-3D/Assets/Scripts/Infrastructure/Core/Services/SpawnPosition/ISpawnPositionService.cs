using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.SpawnPosition
{
    public interface ISpawnPositionService
    {
        Vector3 GetEnemySpawnPosition();
        Vector3 GetPlayerSpawnPosition();
    }
}