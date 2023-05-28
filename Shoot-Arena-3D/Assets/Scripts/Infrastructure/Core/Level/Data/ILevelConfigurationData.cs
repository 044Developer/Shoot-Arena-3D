using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Level.Data
{
    public interface ILevelConfigurationData
    {
        public EnemyType EnemyTypes { get; }
        public float StartRespawnRate { get; }
        public float MinRespawnRate { get; }
        public float SpawnDecreaseStep { get; }
        public int TotalEnemiesCountPerRespawn { get; }
        public int MeleeCountAtLevelValue { get; }
        public int RangeCountAtLevelValue { get; }
    }
}