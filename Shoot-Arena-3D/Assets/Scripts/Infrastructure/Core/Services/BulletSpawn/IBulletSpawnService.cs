using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.BulletSpawn
{
    public interface IBulletSpawnService
    {
        void SpawnPlayerBullet(Vector3 position, Vector3 direction);
        void SpawnEnemyBullet(Vector3 position);
    }
}