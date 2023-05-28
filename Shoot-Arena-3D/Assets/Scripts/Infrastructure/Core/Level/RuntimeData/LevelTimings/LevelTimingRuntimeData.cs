namespace ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings
{
    public class LevelTimingRuntimeData : ILevelTimingRuntimeData
    {
        public bool IsLevelPaused { get; set; }  = false;
        public float CurrentRespawnRate { get; set; }
        public float TimeToNextRespawn { get; set; }
        public float CurrenLevelTime { get; set; }
        public float TimeMultiplier { get; set; }
    }
}