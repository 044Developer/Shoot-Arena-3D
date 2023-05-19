using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.SpawnPosition.Implementation
{
    public class SpawnPositionService : ISpawnPositionService
    {
        
        /*
         * Public
         */
        
        public Vector3 GetEnemySpawnPosition()
        {
            return CalculateEnemyNewPosition();
        }

        public Vector3 GetPlayerSpawnPosition()
        {
            return CalculatePlayerNewPosition();
        }
        
        /*
         * Private
         */

        private Vector3 CalculateEnemyNewPosition()
        {
            return Vector3.zero;
        }

        private Vector3 CalculatePlayerNewPosition()
        {
            return Vector3.zero;
        }
    }
}