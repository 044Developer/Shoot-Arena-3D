using ShootArena.Infrastructure.MonoComponents.Core.CollisionHandler.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.View
{
    public interface IBulletView
    {
        public Transform Transform { get; }
        public Rigidbody Rigidbody { get; }
        public ObjectCollisionHandler ObjectCollisionHandler { get; }
    }
}