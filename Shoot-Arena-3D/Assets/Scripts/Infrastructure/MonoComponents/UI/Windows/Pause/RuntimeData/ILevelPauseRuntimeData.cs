using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.RuntimeData
{
    public interface ILevelPauseRuntimeData
    {
        public Action OnResumeButtonClick { get; }
        public Action OnExitButtonClick { get; }
    }
}