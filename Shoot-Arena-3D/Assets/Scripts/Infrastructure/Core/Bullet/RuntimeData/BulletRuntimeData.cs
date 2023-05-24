using ShootArena.Infrastructure.Core.Bullet.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.RuntimeData
{
    public class BulletRuntimeData : IBulletRuntimeData
    {
        public BulletBase Bullet { get; set; }
        public Vector3 BulletDirection { get; set; }
        public Transform BulletTarget { get; set; }
        public float SpawnStartTime { get; set; }
    }
}