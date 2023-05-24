using ShootArena.Infrastructure.Core.Bullet.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.RuntimeData
{
    public interface IBulletRuntimeData
    {
        public BulletBase Bullet { get; }
        public Vector3 BulletDirection { get; }
        public Transform BulletTarget { get; }
        public float SpawnStartTime { get; }
    }
}