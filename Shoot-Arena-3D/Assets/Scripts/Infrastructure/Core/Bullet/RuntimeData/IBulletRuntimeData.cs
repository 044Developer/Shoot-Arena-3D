using ShootArena.Infrastructure.Core.Bullet.Data.Damage;
using ShootArena.Infrastructure.Core.Bullet.Model;

namespace ShootArena.Infrastructure.Core.Bullet.RuntimeData
{
    public interface IBulletRuntimeData
    {
        public BulletBase Bullet { get; }
        public IBulletDamageData DamageData { get; }
    }
}