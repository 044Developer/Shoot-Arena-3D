using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt.Implementation
{
    public class PlayerUltHandler : IPlayerUltHandler
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
                Mathf.Max(_playerRuntimeData.PlayerStrengthData.MaxStrengthValue, newUltValue);
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
            foreach (IEnemy enemy in _enemyRegistryService.AllEnemies) 
                enemy.Die();
        }
    }
}