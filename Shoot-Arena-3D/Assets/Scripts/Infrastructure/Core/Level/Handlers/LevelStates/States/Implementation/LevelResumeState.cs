using ShootArena.Infrastructure.Core.Level.RuntimeData;

namespace ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation
{
    public class LevelResumeState : BaseLevelState
    {
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData = null;

        public LevelResumeState(ILevelTimingRuntimeData levelTimingRuntimeData)
        {
            _levelTimingRuntimeData = levelTimingRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();
            
            _levelTimingRuntimeData.IsLevelPaused = false;
        }
    }
}