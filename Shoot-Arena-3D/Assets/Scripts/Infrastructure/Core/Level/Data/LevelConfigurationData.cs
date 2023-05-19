using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Level.Data
{
    public class LevelConfigurationData : ILevelConfigurationData
    {
        public EnemyType EnemyTypes { get; }
        public float StartRespawnRate { get; }
        public float MinRespawnRate { get; }
        public float SpawnDecreaseStep { get; }
        public int TotalEnemiesCountPerRespawn { get; }
        public int MeleeCountAtLevelValue { get; }
        public int RangeCountAtLevelValue { get; }

        public LevelConfigurationData(
            EnemyType enemyTypes,
            float startRespawnRate,
            float minRespawnRate,
            float spawnDecreaseStep,
            int totalEnemiesCountPerRespawn
            
            )
        {
            EnemyTypes = enemyTypes;
            StartRespawnRate = startRespawnRate;
            MinRespawnRate = minRespawnRate;
            SpawnDecreaseStep = spawnDecreaseStep;
            TotalEnemiesCountPerRespawn = totalEnemiesCountPerRespawn;
        }

        public LevelConfigurationData(int meleeCountAtLevelValue, int rangeCountAtLevelValue)
        {
            MeleeCountAtLevelValue = meleeCountAtLevelValue;
            RangeCountAtLevelValue = rangeCountAtLevelValue;
        }
    }
}