using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Player.Data.Control;
using ShootArena.Infrastructure.Core.Player.Data.Health;
using ShootArena.Infrastructure.Core.Player.Data.Strength;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp.Implementation
{
    public class PlayerSetUpHandler : IPlayerSetUpHandler
    {
        private readonly PlayerRuntimeData _playerRuntimeData = null;
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;
        private readonly IPlayerHealthHandler _playerHealthHandler = null;
        private readonly IPlayerUltHandler _playerUltHandler = null;

        public PlayerSetUpHandler(
            IPlayerRuntimeData playerRuntimeData,
            ILevelConfigDataModel levelConfigDataModel,
            IPlayerHealthHandler playerHealthHandler,
            IPlayerUltHandler playerUltHandler
        )
        {
            _playerRuntimeData = playerRuntimeData as PlayerRuntimeData;
            _levelConfigDataModel = levelConfigDataModel;
            _playerHealthHandler = playerHealthHandler;
            _playerUltHandler = playerUltHandler;
        }
        
        public void SetUpPlayer()
        {
            SetUpHealth();

            SetUpControl();

            SetUpStrength();
        }

        private void SetUpHealth()
        {
            _playerRuntimeData.HealthData = new PlayerHealthData
                (
                    startHealthValue: _levelConfigDataModel.PlayerConfigurationData.PlayerStartHealthValue,
                    maxHealthValue: _levelConfigDataModel.PlayerConfigurationData.PlayerMaxHealthValue,
                    healthRestoreValue: _levelConfigDataModel.PlayerConfigurationData.HealthRestoreValue
                    );
            
            _playerHealthHandler.SetUpPlayerHealth();
        }

        private void SetUpControl()
        {
            _playerRuntimeData.PlayerControlData = new PlayerControlData
                (
                    moveSpeed: _levelConfigDataModel.PlayerConfigurationData.PlayerMoveSpeed,
                    rotationSpeed: _levelConfigDataModel.PlayerConfigurationData.PlayerRotationSpeed,
                    minRotateHeight: _levelConfigDataModel.PlayerConfigurationData.PlayerRotationMinHeight,
                    maxRotateHeight: _levelConfigDataModel.PlayerConfigurationData.PlayerRotationMaxHeight
                    );
        }

        private void SetUpStrength()
        {
            _playerRuntimeData.PlayerStrengthData = new PlayerStrengthData
                (
                    startStrengthValue: _levelConfigDataModel.PlayerConfigurationData.PlayerStartStrengthValue,
                    maxStrengthValue: _levelConfigDataModel.PlayerConfigurationData.PlayerMaxStrengthValue,
                    minStrengthRestoreValue: _levelConfigDataModel.PlayerConfigurationData.MinStrengthRestoreValue,
                    maxStrengthRestoreValue: _levelConfigDataModel.PlayerConfigurationData.MaxStrengthRestoreValue
                    );
            
            _playerUltHandler.SetUpPlayerUlt();
        }
    }
}