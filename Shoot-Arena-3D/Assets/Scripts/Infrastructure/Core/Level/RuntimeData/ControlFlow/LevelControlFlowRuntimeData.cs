using System;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData.ControlFlow
{
    public class LevelControlFlowRuntimeData : ILevelControlFlowRuntimeData
    {
        public Action OnLevelPrepareStateAction { get; set; }
        public Action OnLevelEnterStateAction { get; set; }
        public Action OnLevelPauseStateAction { get; set; }
        public Action OnLevelResumeStateAction { get; set; }
        public Action OnLevelExitStateAction { get; set; }
        public Action OnLevelRestartStateAction { get; set; }
    }
}