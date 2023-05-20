using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;

namespace ShootArena.Infrastructure.Core.Services.PlayerSetUp.Implementation
{
    public class PlayerSetUpService : IPlayerSetUpService
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;

        public PlayerSetUpService(
            IPlayerRuntimeData playerRuntimeData,
            ILevelConfigDataModel levelConfigDataModel
            )
        {
            _playerRuntimeData = playerRuntimeData;
            _levelConfigDataModel = levelConfigDataModel;
        }
        
        public void SetUpPlayer()
        {
            _playerRuntimeData.HealthData.CurrentHealthValue = _levelConfigDataModel.PlayerConfigurationData.PlayerStartHealthValue;
            _playerRuntimeData.PlayerStrengthData.CurrentStrengthValue = _levelConfigDataModel.PlayerConfigurationData.PlayerStartStrengthValue;
            _playerRuntimeData.PlayerControlData.CurrentMoveSpeed = _levelConfigDataModel.PlayerConfigurationData.PlayerMoveSpeed;
            _playerRuntimeData.PlayerControlData.CurrentRotationSpeed = _levelConfigDataModel.PlayerConfigurationData.PlayerRotationSpeed;
        }
    }
}