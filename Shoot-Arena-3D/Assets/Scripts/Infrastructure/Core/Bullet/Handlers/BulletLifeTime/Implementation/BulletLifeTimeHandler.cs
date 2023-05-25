using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletLifeTime.Implementation
{
    public class BulletLifeTimeHandler : IBulletLifeTimeHandler
    {
        private readonly IBulletRuntimeData _bulletRuntimeData = null;

        public BulletLifeTimeHandler(IBulletRuntimeData bulletRuntimeData)
        {
            _bulletRuntimeData = bulletRuntimeData;
        }
        
        public void Tick()
        {
            if (!IsBulletAlive())
                return;

            if (HasFinishedLifetime())
            {
                _bulletRuntimeData.Bullet.DestroyBullet();
            }
        }

        private bool IsBulletAlive()
        {
            return _bulletRuntimeData.Bullet.gameObject.activeInHierarchy;
        }

        private bool HasFinishedLifetime()
        {
            return Time.realtimeSinceStartup - _bulletRuntimeData.DamageData.SpawnStartTime >
                   _bulletRuntimeData.DamageData.BulletLifeTime;
        }
    }
}