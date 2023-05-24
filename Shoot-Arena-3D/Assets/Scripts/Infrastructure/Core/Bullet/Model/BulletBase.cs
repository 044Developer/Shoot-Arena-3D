using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Bullet.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Model
{
    public abstract class BulletBase : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletView _view = null;

        public IBulletView View => _view;
        public IBulletRuntimeData BulletRuntimeData => runtimeData;
        public IBulletConfigurationData ConfigurationData { get; protected set; }
        public IMemoryPool MemoryPool { get; protected set; }
        
        protected BulletRuntimeData runtimeData = null;
        
        protected void SetSpawnPoint(Vector3 spawnPoint)
        {
            _view.Transform.position = spawnPoint;
        }
    }
}