using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData
{
    public interface IHUDRuntimeData
    {
        public Action OnHealthChanged { get; }
        public Action OnStrengthChanged { get; }
        public Action OnPauseButtonClick { get; }
        public float CurrentHealthPercentValue { get; }
        public float CurrentStrengthPercentValue { get; }
    }
}