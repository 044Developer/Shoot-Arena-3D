using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Mediator
{
    public interface ILevelCountDownMediator : IUIMediator
    {
        void SetUpWindow();
        void OpenWindow();
    }
}