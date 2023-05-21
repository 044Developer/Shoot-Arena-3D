using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;

namespace ShootArena.Infrastructure.Core.Services.OutOfBounds.Implementation
{
    public class OutOfBoundsService : IOutOfBoundsService
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IPlayerSpawnService _playerSpawnService = null;

        public OutOfBoundsService(
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
            _playerRuntimeData.Player.Transform.position.y > 0;

        private void RespawnPlayer() => 
            _playerSpawnService.RespawnPlayer();
    }
}