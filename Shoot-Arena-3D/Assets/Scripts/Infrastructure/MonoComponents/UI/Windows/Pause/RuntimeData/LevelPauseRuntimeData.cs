using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.RuntimeData
{
    public class LevelPauseRuntimeData : ILevelPauseRuntimeData
    {
        public Action OnResumeButtonClick { get; set; }
        public Action OnExitButtonClick { get; set; }
    }
}