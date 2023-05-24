using ShootArena.Infrastructure.Core.Bullet.Data.Type;

namespace ShootArena.Infrastructure.Core.Bullet.Data.Configuration
{
    public class BulletConfigurationData : IBulletConfigurationData
    {
        public BulletType BulletType { get; }
        public float BulletSpeed { get; }
        public float BulletLifeTime { get; }

        public BulletConfigurationData(BulletType bulletType, float bulletSpeed, float bulletLifeTime)
        {
            BulletType = bulletType;
            BulletSpeed = bulletSpeed;
            BulletLifeTime = bulletLifeTime;
        }
    }
}