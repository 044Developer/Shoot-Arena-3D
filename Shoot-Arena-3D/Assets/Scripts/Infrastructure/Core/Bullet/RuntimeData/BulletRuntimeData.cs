using ShootArena.Infrastructure.Core.Bullet.Data.Damage;
using ShootArena.Infrastructure.Core.Bullet.Model;

namespace ShootArena.Infrastructure.Core.Bullet.RuntimeData
{
    public class BulletRuntimeData : IBulletRuntimeData
    {
        public BulletBase Bullet { get; set; }
        public IBulletDamageData DamageData { get; set; }
    }
}