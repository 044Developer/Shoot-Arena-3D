using System;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData
{
    public interface IHUDRuntimeData
    {
        public Action OnHealthChanged { get; }
        public Action OnStrengthChanged { get; }
        public Action OnUltButtonPressed { get; }
        public float CurrentHealthPercentValue { get; }
        public float CurrentStrengthPercentValue { get; }
    }

    public class HUDRuntimeData : IHUDRuntimeData
    {
        public Action OnHealthChanged { get; set; }
        public Action OnStrengthChanged { get; set; }
        public Action OnUltButtonPressed { get; set; }
        public float CurrentHealthPercentValue { get; set; }
        public float CurrentStrengthPercentValue { get; set; }
    }
}