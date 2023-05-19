using ShootArena.Infrastructure.Core.Level.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.LevelTimer
{
    public class LevelTimerService : ILevelTimerService
    {
        private readonly LevelSessionData _levelSessionData = null;

        public LevelTimerService(LevelSessionData levelSessionData)
        {
            _levelSessionData = levelSessionData;
        }

        public void Tick()
        {
            if (_levelSessionData.IsLevelPaused)
                return;
            
            LevelTimerTick();
            RespawnRateTick();
        }
        
        private void LevelTimerTick()
        {
            var tick = Time.deltaTime;
            
            tick = tick * _levelSessionData.TimeMultiplier;
            _levelSessionData.CurrenLevelTime += tick;
        }

        private void RespawnRateTick()
        {
            if (_levelSessionData.TimeToNextRespawn <= 0)
                return;

            var tick = Time.deltaTime;
            
            tick = tick * _levelSessionData.TimeMultiplier;
            _levelSessionData.TimeToNextRespawn -= tick;
        }
    }
}