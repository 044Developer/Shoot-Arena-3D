using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData
{
    public interface ILevelLooseRuntimeData
    {   
        public int TotalEnemiesKilledValue { get; }
        public float TotalTimeSpendValue { get; }
        public Action OnRestartButtonClickAction { get; }
        public Action OnExitButtonClickAction { get; }
    }
}