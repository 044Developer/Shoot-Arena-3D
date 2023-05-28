using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerRestore.Implementation
{
    public class PlayerRestoreHandler : IPlayerRestoreHandler
    {
        private const int HUNDRED_PROBABILITY_VALUE = 101;
        private const int ZERO_PROBABILITY_VALUE = 0;
        private const int HALF_PROBABILITY_VALUE = 50;
        
        private readonly IPlayerHealthHandler _playerHealthHandler = null;
        private readonly IPlayerUltHandler _playerUltHandler = null;

        public PlayerRestoreHandler(
            IPlayerHealthHandler playerHealthHandler,
            IPlayerUltHandler playerUltHandler
            )
        {
            _playerHealthHandler = playerHealthHandler;
            _playerUltHandler = playerUltHandler;
        }
        
        public void RestorePlayerStats()
        {
            CalculateRestoreType();
        }

        private void CalculateRestoreType()
        {
            int chance = Random.Range(ZERO_PROBABILITY_VALUE, HUNDRED_PROBABILITY_VALUE);
            
            if (chance > HALF_PROBABILITY_VALUE)
                RestoreHealth();
            else
                RestoreUlt();
        }

        private void RestoreHealth()
        {
            _playerHealthHandler.RestoreHalfHp();
        }

        private void RestoreUlt()
        {
            _playerUltHandler.RestoreRandomUltPoints();
        }
    }
}