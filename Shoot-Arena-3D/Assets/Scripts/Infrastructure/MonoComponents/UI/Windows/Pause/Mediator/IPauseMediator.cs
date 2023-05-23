using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Mediator
{
    public interface IPauseMediator : IUIMediator
    {
        void OnResumeButtonClicked();
        void OnExitButtonClicked();
    }
}