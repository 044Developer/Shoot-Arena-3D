using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelPauseState : BaseLevelState
    {
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;

        public LevelPauseState(ILevelTimingRuntimeData levelTimingRuntimeData)
        {
            _levelTimingRuntimeData = levelTimingRuntimeData;
        }
        
        public override void Enter()
        {
            base.Enter();

            _levelTimingRuntimeData.IsLevelPaused = true;
        }
    }
}