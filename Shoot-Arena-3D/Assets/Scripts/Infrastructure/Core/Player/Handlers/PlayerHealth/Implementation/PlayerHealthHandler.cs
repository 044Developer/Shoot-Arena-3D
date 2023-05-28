using ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth.Implementation
{
    public class PlayerHealthHandler : IPlayerHealthHandler
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerDieHandler _playerDieHandler = null;
        private readonly HUDRuntimeData _hudRuntimeData;

        public PlayerHealthHandler(
            IPlayerRuntimeData playerRuntimeData,
            IHUDRuntimeData hudRuntimeData,
            IPlayerDieHandler playerDieHandler
            )
        {
            _playerRuntimeData = playerRuntimeData;
            _playerDieHandler = playerDieHandler;
            _hudRuntimeData = hudRuntimeData as HUDRuntimeData;
        }
        
        public void SetUpPlayerHealth()
        {
            _playerRuntimeData.HealthData.CurrentHealthValue = _playerRuntimeData.HealthData.MaxHealthValue;
            
            UpdateHealthHUD();
        }

        public void ReceiveDamage(float value)
        {
            DecreaseHealth(value);
            UpdateHealthHUD();
            
            if (IsPlayerDead()) 
                _playerDieHandler.Die();
        }

        public void TopUpHealth(float value)
        {
            IncreaseHealth(value);
            UpdateHealthHUD();
        }

        public void RestoreHalfHp()
        {
            IncreaseHealth(_playerRuntimeData.HealthData.HealthRestoreValue);
            UpdateHealthHUD();
        }

        private bool IsPlayerDead() => 
            _playerRuntimeData.HealthData.CurrentHealthValue <= 0;

        private void DecreaseHealth(float value)
        {
            float newHealthValue = _playerRuntimeData.HealthData.CurrentHealthValue - value;
            _playerRuntimeData.HealthData.CurrentHealthValue =
                Mathf.Max(_playerRuntimeData.HealthData.MinHealthValue, newHealthValue);
        }

        private void IncreaseHealth(float value)
        {
            float newHealthValue = _playerRuntimeData.HealthData.CurrentHealthValue + value;
            _playerRuntimeData.HealthData.CurrentHealthValue =
                Mathf.Min(_playerRuntimeData.HealthData.MaxHealthValue, newHealthValue);
        }

        private void UpdateHealthHUD()
        {
            _hudRuntimeData.CurrentHealthPercentValue = _playerRuntimeData.HealthData.CurrentHealthValue /
                                                        _playerRuntimeData.HealthData.MaxHealthValue;
            
            _hudRuntimeData.OnHealthChanged?.Invoke();
        }
    }
}
