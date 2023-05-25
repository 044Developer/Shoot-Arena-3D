using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Data.Damage
{
    public interface IBulletDamageData
    {
        public float BulletDamage { get; }
        public float BulletSpeed { get; }
        public Vector3 BulletDirection { get; }
        public float SpawnStartTime { get; }
        public float BulletLifeTime { get; }
    }
}