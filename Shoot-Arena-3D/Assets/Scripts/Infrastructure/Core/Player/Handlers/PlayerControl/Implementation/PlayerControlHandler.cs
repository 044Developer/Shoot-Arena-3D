using ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerControl.Implementation
{
    public class PlayerControlHandler : IPlayerControlHandler
    {
        private const float MIN_INPUT_TREASHOLD = 0.01f;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerInputHandler _inputHandler = null;

        private float _currentHorizontalRotation = 0f;
        private float _currentVerticalRotation = 0f;
        
        public PlayerControlHandler
        (
            IPlayerMobileInputHandler mobileInputHandler,
            IPlayerStandaloneInputHandler standaloneInputHandler,
            IDeviceCheckModule deviceCheckModule,
            IPlayerRuntimeData playerRuntimeData
        )
        {
            _playerRuntimeData = playerRuntimeData;
            
            if (deviceCheckModule.CurrentDeviceType.HasFlag(CurrentDeviceType.Mobile))
                _inputHandler = mobileInputHandler;
            else
                _inputHandler = standaloneInputHandler;
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

            if (_inputHandler.MoveAxis.sqrMagnitude > MIN_INPUT_TREASHOLD)
            {
                movementVector = _playerRuntimeData.Player.View.Transform.right * _inputHandler.MoveAxis.x + _playerRuntimeData.Player.View.Transform.forward * _inputHandler.MoveAxis.y;
            }

            movementVector += Physics.gravity;

            _playerRuntimeData.Player.View.CharacterController.Move(_playerRuntimeData.PlayerControlData.CurrentMoveSpeed * movementVector * Time.deltaTime);
        }

        private void RotatePlayer()
        {
            if (_inputHandler.RotateAxis.sqrMagnitude > MIN_INPUT_TREASHOLD)
            {
                float horizontalRotation = _inputHandler.RotateAxis.x * _playerRuntimeData.PlayerControlData.CurrentRotationSpeed * Time.deltaTime;
                float verticalRotation = _inputHandler.RotateAxis.y * _playerRuntimeData.PlayerControlData.CurrentRotationSpeed * Time.deltaTime;

                _currentVerticalRotation += horizontalRotation;
                _currentHorizontalRotation -= verticalRotation;
                
                _currentHorizontalRotation = Mathf.Clamp(_currentHorizontalRotation, -_playerRuntimeData.PlayerControlData.MaxRotateHeight, _playerRuntimeData.PlayerControlData.MinRotateHeight);
                
                _playerRuntimeData.Player.View.Transform.rotation = Quaternion.Euler(_currentHorizontalRotation, _currentVerticalRotation, 0f);
            }
        }

        private bool HasActivePlayer() => 
            _playerRuntimeData.Player != null;
    }
}