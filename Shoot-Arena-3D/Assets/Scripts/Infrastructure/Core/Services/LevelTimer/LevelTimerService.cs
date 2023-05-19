using ShootArena.Infrastructure.Core.Level.Data;
using ShootArena.Infrastructure.Core.Level.Model;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.LevelTimer
{
    public class LevelTimerService : ILevelTimerService
    {
        private readonly LevelSessionModel _levelSessionModel = null;

        public LevelTimerService(LevelSessionModel levelSessionModel)
        {
            _levelSessionModel = levelSessionModel;
        }

        public void Tick()
        {
            if (_levelSessionModel.IsLevelPaused)
                return;
            
            LevelTimerTick();
            RespawnRateTick();
        }
        
        private void LevelTimerTick()
        {
            var tick = Time.deltaTime;
            
            tick = tick * _levelSessionModel.TimeMultiplier;
            _levelSessionModel.CurrenLevelTime += tick;
        }

        private void RespawnRateTick()
        {
            if (_levelSessionModel.TimeToNextRespawn <= 0)
                return;

            var tick = Time.deltaTime;
            
            tick = tick * _levelSessionModel.TimeMultiplier;
            _levelSessionModel.TimeToNextRespawn -= tick;
        }
    }
}