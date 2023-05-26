using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp.Implementation
{
    public class PlayerSetUpHandler : IPlayerSetUpHandler
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly ILevelConfigDataModel _levelConfigDataModel = null;

        public PlayerSetUpHandler(
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
            _playerRuntimeData.PlayerControlData.MinRotateHeight = _levelConfigDataModel.PlayerConfigurationData.PlayerRotationMinHeight;
            _playerRuntimeData.PlayerControlData.MaxRotateHeight = _levelConfigDataModel.PlayerConfigurationData.PlayerRotationMaxHeight;
        }
    }
}