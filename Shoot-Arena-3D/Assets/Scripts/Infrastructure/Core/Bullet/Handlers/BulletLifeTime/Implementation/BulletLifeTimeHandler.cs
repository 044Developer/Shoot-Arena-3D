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
            if (Time.realtimeSinceStartup - _bulletRuntimeData.SpawnStartTime > _bulletRuntimeData.Bullet.ConfigurationData.BulletLifeTime)
            {
                _bulletRuntimeData.Bullet.MemoryPool.Despawn(_bulletRuntimeData.Bullet);
            }
        }
    }
}