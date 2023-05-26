using System;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt.Implementation
{
    public class PlayerUltHandler : IPlayerUltHandler, IInitializable, IDisposable
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly HUDRuntimeData _hudRuntimeData = null;
        private readonly IEnemyRegistryService _enemyRegistryService;

        public PlayerUltHandler(
            IPlayerRuntimeData playerRuntimeData,
            IHUDRuntimeData hudRuntimeData,
            IEnemyRegistryService enemyRegistryService)
        {
            _playerRuntimeData = playerRuntimeData;
            _hudRuntimeData = hudRuntimeData as HUDRuntimeData;
            _enemyRegistryService = enemyRegistryService;
        }
        
        public void SetUpPlayerUlt()
        {
            _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue =
                _playerRuntimeData.PlayerStrengthData.StartStrengthValue;

            UpdateHealthHUD();
        }

        public void AddUltPoints(float newPoints)
        {
            IncreaseUltValue(newPoints);
            
            UpdateHealthHUD();
        }

        public void UseUlt()
        {
            DecreaseAllPoints();
            
            UpdateHealthHUD();

            KillAllActiveEnemies();
        }

        private void IncreaseUltValue(float value)
        {
            float newUltValue = _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue + value;
            _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue =
                Mathf.Clamp(newUltValue, _playerRuntimeData.PlayerStrengthData.MinStrengthValue,
                    _playerRuntimeData.PlayerStrengthData.MaxStrengthValue);
        }

        private void DecreaseAllPoints()
        {
            _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue =
                _playerRuntimeData.PlayerStrengthData.MinStrengthValue;
        }

        private void UpdateHealthHUD()
        {
            _hudRuntimeData.CurrentStrengthPercentValue = _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue /
                                                        _playerRuntimeData.PlayerStrengthData.MaxStrengthValue;
            
            _hudRuntimeData.OnStrengthChanged?.Invoke();
        }

        private void KillAllActiveEnemies()
        {
            List<IEnemy> allActiveEnemies = new List<IEnemy>();
            allActiveEnemies.AddRange(_enemyRegistryService.AllEnemies);
            
            foreach (IEnemy enemy in allActiveEnemies) 
                enemy.Die();
        }

        public void Initialize()
        {
            _hudRuntimeData.OnUltButtonPressed += UseUlt;
        }

        public void Dispose()
        {
            _hudRuntimeData.OnUltButtonPressed -= UseUlt;
        }
    }
}