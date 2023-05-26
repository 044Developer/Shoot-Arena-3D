﻿using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth.Implementation
{
    public class EnemyHealthHandler : IEnemyHealthHandler
    {
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IEnemyStateHandler _enemyStateHandler = null;
        private readonly IPlayerUltHandler _playerUltHandler = null;

        public EnemyHealthHandler(
            IEnemyRuntimeData enemyRuntimeData,
            IEnemyStateHandler enemyStateHandler,
            IPlayerUltHandler playerUltHandler
            )
        {
            _enemyRuntimeData = enemyRuntimeData;
            _enemyStateHandler = enemyStateHandler;
            _playerUltHandler = playerUltHandler;
        }
        
        public void ReceiveDamage(float value)
        {
            DecreaseHealth(value);
            
            if (IsEnemyDead())
            {
                _playerUltHandler.AddUltPoints(_enemyRuntimeData.EnemyDamageData.RewardPoints);
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