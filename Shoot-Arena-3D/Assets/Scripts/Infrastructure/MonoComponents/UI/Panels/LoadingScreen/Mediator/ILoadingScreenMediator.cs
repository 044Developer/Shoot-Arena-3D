using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Mediator
{
    public interface ILoadingScreenMediator : IUIMediator
    {
        void Initialize();
        void Execute();
    }
}