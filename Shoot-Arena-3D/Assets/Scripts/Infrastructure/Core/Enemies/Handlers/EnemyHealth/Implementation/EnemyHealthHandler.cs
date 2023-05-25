using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth.Implementation
{
    public class EnemyHealthHandler : IEnemyHealthHandler
    {
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IEnemyStateHandler _enemyStateHandler = null;

        public EnemyHealthHandler(
            IEnemyRuntimeData enemyRuntimeData,
            IEnemyStateHandler enemyStateHandler)
        {
            _enemyRuntimeData = enemyRuntimeData;
            _enemyStateHandler = enemyStateHandler;
        }
        
        public void ReceiveDamage(int value)
        {
            DecreaseHealth(value);

            if (IsEnemyDead())
            {
                _enemyStateHandler.EnterState<EnemyDieState>();
            }
        }

        private bool IsEnemyDead() => 
            _enemyRuntimeData.Enemy.HealthData.CurrentHealth <= 0;

        private void DecreaseHealth(int value)
        {
            float newHealthValue = _enemyRuntimeData.Enemy.HealthData.CurrentHealth - value;
            _enemyRuntimeData.Enemy.HealthData.CurrentHealth =
                Mathf.Max(_enemyRuntimeData.Enemy.HealthData.MinHealth, newHealthValue);
        }
    }
}