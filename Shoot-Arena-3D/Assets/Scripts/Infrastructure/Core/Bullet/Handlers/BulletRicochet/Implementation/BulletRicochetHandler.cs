using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletRicochet.Implementation
{
    public class BulletRicochetHandler : IBulletRicochetHandler
    {
        private readonly IPlayerRuntimeData _playerHealthHandler = null;
        private readonly IBulletRuntimeData _bulletRuntimeData = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;

        public BulletRicochetHandler(
            IPlayerRuntimeData playerHealthHandler,
            IBulletRuntimeData bulletRuntimeData,
            IEnemyRegistryService enemyRegistryService)
        {
            _playerHealthHandler = playerHealthHandler;
            _bulletRuntimeData = bulletRuntimeData;
            _enemyRegistryService = enemyRegistryService;
        }
        
        public bool IsRicochetActive()
        {
            float probability = (_playerHealthHandler.HealthData.MaxHealthValue - _playerHealthHandler.HealthData.CurrentHealthValue) / (float)_playerHealthHandler.HealthData.MaxHealthValue;
            
            float randomValue = Random.value;
            
            return randomValue <= probability;
        }

        public void CalculateClosestEnemy(IEnemy damageTarget)
        {
            IEnemy closestEnemy = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 bulletPosition = _bulletRuntimeData.Bullet.View.Transform.position;

            foreach (IEnemy enemy in _enemyRegistryService.AllEnemies)
            {
                if (enemy == damageTarget)
                    continue;
                
                Vector3 enemyPosition = enemy.EnemyView.EnemyTransform.position;
                Vector3 directionToEnemy = enemyPosition - bulletPosition;
                float distanceSqr = directionToEnemy.sqrMagnitude;

                if (distanceSqr < closestDistanceSqr)
                {
                    closestDistanceSqr = distanceSqr;
                    closestEnemy = enemy;
                }
            }

            _bulletRuntimeData.DamageData.NextRicochetTarget = closestEnemy;
        }
    }
}