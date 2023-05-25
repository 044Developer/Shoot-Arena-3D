using System;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.View
{
    [Serializable]
    public class BulletView : IBulletView
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private Rigidbody _rigidbody = null;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidbody;
    }
}