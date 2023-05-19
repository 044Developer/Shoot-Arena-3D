using ShootArena.Infrastructure.Core.Level.Data;

namespace ShootArena.Infrastructure.Core.Level.Model
{
    public class LevelSessionModel
    {
        public ILevelConfigurationData LevelConfigurationData { get; }
        public bool IsLevelPaused { get; set; }
        public float CurrentRespawnRate { get; set; }
        public float TimeToNextRespawn { get; set; }
        public float CurrenLevelTime { get; set; }
        public float TimeMultiplier { get; }
        public int TotalActiveMeleeEnemiesCount { get; }
        public int TotalActiveRangeEnemiesCount { get; }
    }
}