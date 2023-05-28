using System;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData.ControlFlow
{
    public interface ILevelControlFlowRuntimeData
    {
        public Action OnLevelPrepareStateAction { get; }
        public Action OnLevelEnterStateAction { get; }
        public Action OnLevelPauseStateAction { get; }
        public Action OnLevelResumeStateAction { get; }
        public Action OnLevelExitStateAction { get; }
        public Action OnLevelRestartStateAction { get;}
    }
}