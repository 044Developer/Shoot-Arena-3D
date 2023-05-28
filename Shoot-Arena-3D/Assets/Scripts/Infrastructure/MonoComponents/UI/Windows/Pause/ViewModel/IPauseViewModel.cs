using ShootArena.Infrastructure.MonoComponents.UI.Base;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.ViewModel
{
    public interface IPauseViewModel : IUIViewModel
    { 
        public Button ResumeButton { get; }
        public Button ExitButton { get; }
    }
}