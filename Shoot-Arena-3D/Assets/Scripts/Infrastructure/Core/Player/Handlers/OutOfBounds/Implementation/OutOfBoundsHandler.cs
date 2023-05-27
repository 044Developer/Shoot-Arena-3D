using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;

namespace ShootArena.Infrastructure.Core.Player.Handlers.OutOfBounds.Implementation
{
    public class OutOfBoundsHandler : IOutOfBoundsHandler
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerSpawnService _playerSpawnService = null;

        public OutOfBoundsHandler(
            IPlayerRuntimeData playerRuntimeData,
            IPlayerSpawnService playerSpawnService)
        {
            _playerRuntimeData = playerRuntimeData;
            _playerSpawnService = playerSpawnService;
        }
        
        public void Tick()
        {
            if (!HasActivePlayer())
                return;

            if (IsPlayerAboveArena())
                return;
            
            RespawnPlayer();
        }

        private bool HasActivePlayer() => 
            _playerRuntimeData.Player != null;

        private bool IsPlayerAboveArena() =>
            _playerRuntimeData.Player.IsPlayerGrounded();

        private void RespawnPlayer()
        {
            _playerRuntimeData.PlayerControlData.PlayerRespawnedAction?.Invoke();
            _playerSpawnService.RespawnPlayer();
        }
    }
}