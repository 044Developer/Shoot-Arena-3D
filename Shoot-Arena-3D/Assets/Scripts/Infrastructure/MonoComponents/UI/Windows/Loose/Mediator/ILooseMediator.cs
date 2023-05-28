using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator
{
    public interface ILooseMediator : IUIMediator
    {
        void SetWindowData();
        void OnRestartButtonClicked();
        void OnExitButtonClicked();
    }
}