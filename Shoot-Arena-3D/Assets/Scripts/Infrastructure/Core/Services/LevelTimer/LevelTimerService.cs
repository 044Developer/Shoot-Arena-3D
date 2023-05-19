using ShootArena.Infrastructure.Core.Level.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.LevelTimer
{
    public class LevelTimerService : ILevelTimerService
    {
        private readonly ILevelTimingRuntimeData _timingRuntimeData = null;

        public LevelTimerService(ILevelTimingRuntimeData timingRuntimeData)
        {
            _timingRuntimeData = timingRuntimeData;
            _timingRuntimeData.TimeMultiplier = 1f;
        }

        public void Tick()
        {
            if (_timingRuntimeData.IsLevelPaused)
                return;
            
            LevelTimerTick();
            RespawnRateTick();
        }
        
        private void LevelTimerTick()
        {
            var tick = Time.deltaTime;
            
            tick = tick * _timingRuntimeData.TimeMultiplier;
            _timingRuntimeData.CurrenLevelTime += tick;
        }

        private void RespawnRateTick()
        {
            if (_timingRuntimeData.TimeToNextRespawn <= 0)
                return;

            var tick = Time.deltaTime;
            
            tick = tick * _timingRuntimeData.TimeMultiplier;
            _timingRuntimeData.TimeToNextRespawn -= tick;
        }
    }
}