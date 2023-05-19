namespace ShootArena.Infrastructure.Core.Level.RuntimeData
{
    public class LevelEnemiesRuntimeData : ILevelEnemiesRuntimeData
    {
        public int TotalActiveMeleeEnemiesCount { get; set; }
        public int TotalActiveRangeEnemiesCount { get; set; }
    }
}