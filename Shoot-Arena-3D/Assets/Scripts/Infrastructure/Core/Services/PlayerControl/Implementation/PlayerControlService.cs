using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.PlayerInput;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerControl.Implementation
{
    public class PlayerControlService : IPlayerControlService
    {
        private const float MIN_INPUT_TREASHOLD = 0.01f;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerInputService _inputService = null;

        private float _currentHorizontalRotation = 0f;
        private float _currentVerticalRotation = 0f;
        
        public PlayerControlService
        (
            IPlayerMobileInputService mobileInputService,
            IPlayerStandaloneInputService standaloneInputService,
            IDeviceCheckModule deviceCheckModule,
            IPlayerRuntimeData playerRuntimeData
        )
        {
            _playerRuntimeData = playerRuntimeData;
            
            if (deviceCheckModule.CurrentDeviceType.HasFlag(CurrentDeviceType.Mobile))
                _inputService = mobileInputService;
            else
                _inputService = standaloneInputService;
        }
        
        public void Tick()
        {
            if (!HasActivePlayer())
                return;

            MovePlayer();
            RotatePlayer();
        }

        private void MovePlayer()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.MoveAxis.sqrMagnitude > MIN_INPUT_TREASHOLD)
            {
                movementVector = _playerRuntimeData.Player.Transform.right * _inputService.MoveAxis.x + _playerRuntimeData.Player.Transform.forward * _inputService.MoveAxis.y;
            }

            movementVector += Physics.gravity;

            _playerRuntimeData.Player.CharacterController.Move(_playerRuntimeData.PlayerControlData.CurrentMoveSpeed * movementVector * Time.deltaTime);
        }

        private void RotatePlayer()
        {
            if (_inputService.RotateAxis.sqrMagnitude > MIN_INPUT_TREASHOLD)
            {
                float horizontalRotation = _inputService.RotateAxis.x * _playerRuntimeData.PlayerControlData.CurrentRotationSpeed * Time.deltaTime;
                float verticalRotation = _inputService.RotateAxis.y * _playerRuntimeData.PlayerControlData.CurrentRotationSpeed * Time.deltaTime;

                _currentVerticalRotation += horizontalRotation;
                _currentHorizontalRotation -= verticalRotation;
                
                _currentHorizontalRotation = Mathf.Clamp(_currentHorizontalRotation, -_playerRuntimeData.PlayerControlData.MaxRotateHeight, _playerRuntimeData.PlayerControlData.MinRotateHeight);
                
                _playerRuntimeData.Player.Transform.rotation = Quaternion.Euler(_currentHorizontalRotation, _currentVerticalRotation, 0f);
            }
        }

        private bool HasActivePlayer() => 
            _playerRuntimeData.Player != null;
    }
}