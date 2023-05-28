using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData
{
    public class LevelLooseRuntimeData : ILevelLooseRuntimeData
    {
        public int TotalEnemiesKilledValue { get; set; }
        public float TotalTimeSpendValue { get; set; }
        public Action OnRestartButtonClickAction { get; set; }
        public Action OnExitButtonClickAction { get; set; }
    }
}