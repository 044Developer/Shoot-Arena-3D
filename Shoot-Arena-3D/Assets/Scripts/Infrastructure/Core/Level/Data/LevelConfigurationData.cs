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
            int totalEnemiesCountPerRespawn,
            int meleeCountAtLevelValue,
            int rangeCountAtLevelValue
        )
        {
            EnemyTypes = enemyTypes;
            StartRespawnRate = startRespawnRate;
            MinRespawnRate = minRespawnRate;
            SpawnDecreaseStep = spawnDecreaseStep;
            TotalEnemiesCountPerRespawn = totalEnemiesCountPerRespawn;
            MeleeCountAtLevelValue = meleeCountAtLevelValue;
            RangeCountAtLevelValue = rangeCountAtLevelValue;
        }
    }
}