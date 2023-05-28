using ShootArena.Infrastructure.MonoComponents.UI.Base;
using TMPro;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel
{
    public interface ILooseViewModel : IUIViewModel
    {
        public TextMeshProUGUI TotalKillText { get; }
        public TextMeshProUGUI TotalTimeText { get; }
        public Button RestartButton { get; }
        public Button ExitButton { get; }
    }
}