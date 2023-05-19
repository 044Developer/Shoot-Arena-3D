namespace ShootArena.Infrastructure.Core.Level.RuntimeData
{
    public interface ILevelEnemiesRuntimeData
    {
        public int TotalActiveMeleeEnemiesCount { get; set; }
        public int TotalActiveRangeEnemiesCount { get; set; }
    }
}