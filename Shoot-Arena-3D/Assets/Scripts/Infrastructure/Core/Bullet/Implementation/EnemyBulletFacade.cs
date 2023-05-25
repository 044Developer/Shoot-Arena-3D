﻿using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Model;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Data.TakeDamage;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Implementation
{
    public class EnemyBulletFacade : BulletBase, IPoolable<IBulletConfigurationData, Vector3, IMemoryPool>
    {
        private const string PLAYER_TAG = "Player";

        private IPlayerRuntimeData _playerRuntimeData = null;
        
        [Inject]
        public void Construct(IBulletRuntimeData runtimeData, IPlayerRuntimeData playerRuntimeData)
        {
            bulletRuntimeData = runtimeData as BulletRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }
        
        public void OnSpawned(IBulletConfigurationData config, Vector3 spawnPos, IMemoryPool memoryPool)
        {
            bulletPool = memoryPool;
            bulletConfiguration = config;
            
            SubscribeEvents();
            SetUpBullet(spawnPos, Vector3.forward);
        }
        
        public void OnDespawned()
        {
            UnSubscribeEvents();
        }

        private void SubscribeEvents()
        {
            View.ObjectCollisionHandler.OnCollisionEnterEvent += OnBulletHitAction;
        }

        private void UnSubscribeEvents()
        {
            View.ObjectCollisionHandler.OnCollisionEnterEvent -= OnBulletHitAction;
        }
        
        public class Factory : PlaceholderFactory<IBulletConfigurationData, Vector3, EnemyBulletFacade>
        {
        }

        public override void OnBulletHitAction(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out ITakeDamage damageTarget))
                return;
            
            damageTarget.ReceiveDamage(bulletConfiguration.BulletDamage);
            DestroyBullet();
        }
    }
}