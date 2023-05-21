using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.OutOfBounds.Implementation
{
    public class OutOfBoundsService : IOutOfBoundsService
    {
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public OutOfBoundsService(IPlayerRuntimeData playerRuntimeData)
        {
            _playerRuntimeData = playerRuntimeData;
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

        private bool IsPlayerAboveArena()
        {
            return _playerRuntimeData.Player.Transform.position.y > 0;
        }

        private void RespawnPlayer()
        {
            _playerRuntimeData.Player.SetPosition(Vector3.zero);
        }
    }
}