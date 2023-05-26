using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar.Implementation
{
    public class EnemyHealthBarHandler : IEnemyHealthBarHandler, ITickable
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;

        public EnemyHealthBarHandler(IPlayerRuntimeData playerRuntimeData, IEnemyRuntimeData enemyRuntimeData)
        {
            _playerRuntimeData = playerRuntimeData;
            _enemyRuntimeData = enemyRuntimeData;
        }
        
        public void UpdateHealthBar()
        {
            float currentHealthValueInPercent = _enemyRuntimeData.EnemyHealthData.CurrentHealth /
                                                _enemyRuntimeData.EnemyHealthData.MaxHealth;

            _enemyRuntimeData.Enemy.EnemyView.HealthBarSliderImage.fillAmount = currentHealthValueInPercent;
        }
        
        public void Tick()
        {
            var currentRotation = _enemyRuntimeData.Enemy.EnemyView.HealthBarTransform.position -
                                  _playerRuntimeData.Player.View.Transform.position;
            
            _enemyRuntimeData.Enemy.EnemyView.HealthBarTransform.rotation = Quaternion.LookRotation(currentRotation);
        }
    }
}