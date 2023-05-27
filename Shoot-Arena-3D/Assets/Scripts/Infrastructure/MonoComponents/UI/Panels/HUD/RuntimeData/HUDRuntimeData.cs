using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData
{
    public class HUDRuntimeData : IHUDRuntimeData
    {
        public Action OnHealthChanged { get; set; }
        public Action OnStrengthChanged { get; set; }
        public Action OnPauseButtonClick { get; set; }
        public Action OnUltButtonPressed { get; set; }
        public float CurrentHealthPercentValue { get; set; }
        public float CurrentStrengthPercentValue { get; set; }
    }
}