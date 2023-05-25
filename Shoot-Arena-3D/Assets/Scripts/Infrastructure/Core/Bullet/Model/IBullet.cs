﻿using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Bullet.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Model
{
    public interface IBullet
    {
        public IBulletView View { get; }
        public IBulletConfigurationData ConfigurationData { get; }
        public IMemoryPool MemoryPool { get; }
        public void OnBulletHitAction(Collision collision);
    }
}