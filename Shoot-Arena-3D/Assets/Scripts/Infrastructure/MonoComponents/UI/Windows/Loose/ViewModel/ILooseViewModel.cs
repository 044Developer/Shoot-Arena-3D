using ShootArena.Infrastructure.MonoComponents.UI.Base;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel
{
    public interface ILooseViewModel : IUIViewModel
    {
        public Button RestartButton { get; }
        public Button ExitButton { get; }
    }
}