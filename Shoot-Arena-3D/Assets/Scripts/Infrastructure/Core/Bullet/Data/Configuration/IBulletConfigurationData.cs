using ShootArena.Infrastructure.Core.Bullet.Data.Type;

namespace ShootArena.Infrastructure.Core.Bullet.Data.Configuration
{
    public interface IBulletConfigurationData
    {
        public BulletType BulletType { get; }
        public float BulletSpeed { get; }
        public float BulletLifeTime { get; }
        public float BulletDamage { get; }
    }
}