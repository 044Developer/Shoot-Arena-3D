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
        
        public void ReceiveDamage(float value)
        {
            DecreaseHealth(value);

            if (IsEnemyDead())
            {
                Debug.Log("ENEMY DEAD");
                _enemyStateHandler.EnterState<EnemyDieState>();
            }
        }

        private bool IsEnemyDead() => 
            _enemyRuntimeData.EnemyHealthData.CurrentHealth <= 0;

        private void DecreaseHealth(float value)
        {
            float newHealthValue = _enemyRuntimeData.EnemyHealthData.CurrentHealth - value;
            _enemyRuntimeData.EnemyHealthData.CurrentHealth =
                Mathf.Max(_enemyRuntimeData.EnemyHealthData.MinHealth, newHealthValue);
        }
    }
}