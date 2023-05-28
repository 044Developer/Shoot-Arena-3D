namespace ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings
{
    public interface ILevelTimingRuntimeData
    {
        public bool IsLevelPaused { get; set; }
        public float CurrentRespawnRate { get; set; }
        public float TimeToNextRespawn { get; set; }
        public float CurrenLevelTime { get; set; }
        public float TimeMultiplier { get; set; }
    }
}

