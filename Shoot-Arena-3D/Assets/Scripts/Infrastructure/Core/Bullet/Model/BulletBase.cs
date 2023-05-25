using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Data.Damage;
using ShootArena.Infrastructure.Core.Bullet.Data.Type;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Bullet.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Model
{
    public abstract class BulletBase : MonoBehaviour, IBullet
    {
        [SerializeField] private BulletView _view = null;

        public BulletType BulletType { get; private set; }
        public IBulletView View => _view;
        
        protected IBulletConfigurationData bulletConfiguration = null;
        protected BulletRuntimeData bulletRuntimeData = null;
        protected IMemoryPool bulletPool = null;

        public abstract void OnBulletHitAction(Collision collision);

        public void DestroyBullet()
        {
            bulletPool.Despawn(this);
        }

        protected void SetUpBullet(Vector3 spawnPoint, Vector3 direction)
        {
            BulletType = bulletConfiguration.BulletType;
            _view.Transform.position = spawnPoint;
            bulletRuntimeData.Bullet = this;

            SetUpDamageData(direction);
        }

        protected void ResetPosition()
        {
            _view.Transform.position = Vector3.zero;
            _view.Transform.rotation = _view.Transform.rotation;
        }

        private void SetUpDamageData(Vector3 bulletDirection)
        {
            bulletRuntimeData.DamageData = new BulletDamageData(
                bulletDamage: bulletConfiguration.BulletDamage,
                bulletDirection: bulletDirection,
                spawnStartTime: Time.realtimeSinceStartup,
                bulletLifeTime: bulletConfiguration.BulletLifeTime,
                bulletSpeed: bulletConfiguration.BulletSpeed
                );
        }
    }
}