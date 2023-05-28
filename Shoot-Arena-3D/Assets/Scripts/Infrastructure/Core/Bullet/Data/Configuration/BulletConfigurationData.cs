using ShootArena.Infrastructure.Core.Bullet.Data.Type;

namespace ShootArena.Infrastructure.Core.Bullet.Data.Configuration
{
    public class BulletConfigurationData : IBulletConfigurationData
    {
        public BulletType BulletType { get; }
        public float BulletSpeed { get; }
        public float BulletLifeTime { get; }
        public float BulletDamage { get; }

        public BulletConfigurationData(BulletType bulletType, float bulletSpeed, float bulletLifeTime, float bulletDamage)
        {
            BulletType = bulletType;
            BulletSpeed = bulletSpeed;
            BulletLifeTime = bulletLifeTime;
            BulletDamage = bulletDamage;
        }
    }
}