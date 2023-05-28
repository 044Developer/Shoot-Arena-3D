using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.LevelTimer.Implementation
{
    public class LevelTimerService : ILevelTimerService
    {
        private const int MSECONDS_IN_SECOND = 60;
        
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
            
            tick *= _timingRuntimeData.TimeMultiplier;
            _timingRuntimeData.CurrenLevelTime = (_timingRuntimeData.CurrenLevelTime + tick) % MSECONDS_IN_SECOND;
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