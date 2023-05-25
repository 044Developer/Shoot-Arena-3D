using System;
using ShootArena.Infrastructure.MonoComponents.Core.CollisionHandler.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.View
{
    [Serializable]
    public class BulletView : IBulletView
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private ObjectCollisionHandler _collisionHandler = null;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidbody;
        public ObjectCollisionHandler ObjectCollisionHandler => _collisionHandler;
    }
}