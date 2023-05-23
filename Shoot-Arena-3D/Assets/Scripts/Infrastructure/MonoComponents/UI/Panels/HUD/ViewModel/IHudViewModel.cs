using ShootArena.Infrastructure.MonoComponents.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel
{
    public interface IHudViewModel : IUIViewModel
    {
        public GameObject StatsHolder { get; }
        public RectTransform PlayerHpProgressBackRect { get; }
        public RectTransform PlayerHpProgressRect { get; }
        public RectTransform PlayerUltProgressBackRect { get; }
        public RectTransform PlayerUltProgressRect { get; }
        public Button FireButton { get; }
        public Button UltButton { get; }
    }
}