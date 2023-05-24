using System;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.View
{
    [Serializable]
    public class BulletView : IBulletView
    {
        [SerializeField] private Transform _transform = null;

        public Transform Transform => _transform;
    }
}