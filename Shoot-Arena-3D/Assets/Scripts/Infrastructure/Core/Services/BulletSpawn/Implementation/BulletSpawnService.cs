using System;
using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Data.Type;
using ShootArena.Infrastructure.Core.Bullet.Implementation;
using ShootArena.Infrastructure.Core.Level.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.BulletSpawn.Implementation
{
    public class BulletSpawnService : IBulletSpawnService
    {
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly PlayerBulletFacade.Factory _playerBulletFactory = null;
        private readonly EnemyBulletFacade.Factory _enemyBulletFactory = null;

        public BulletSpawnService(
            ILevelConfigDataModel levelConfigDataModel,
            PlayerBulletFacade.Factory playerBulletFactory,
            EnemyBulletFacade.Factory enemyBulletFactory
            )
        {
            _levelConfigDataModel = levelConfigDataModel;
            _playerBulletFactory = playerBulletFactory;
            _enemyBulletFactory = enemyBulletFactory;
        }

        public void SpawnPlayerBullet(Vector3 position, Vector3 direction)
        {
            IBulletConfigurationData config = GetCorrectConfig(BulletType.Player);
            
            _playerBulletFactory.Create(config, position, direction);
        }

        public void SpawnEnemyBullet(Vector3 position, Transform target)
        {
            IBulletConfigurationData config = GetCorrectConfig(BulletType.Enemy);
            
            _enemyBulletFactory.Create(config, position,target);
        }

        private IBulletConfigurationData GetCorrectConfig(BulletType type) => 
            _levelConfigDataModel.bulletConfigurationData.Find(config => config.BulletType == type);
    }
}