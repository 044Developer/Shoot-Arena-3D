using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Mediator
{
    public interface ISplashScreenMediator : IUIMediator
    {
        public void Initialize();
        public void Execute();
    }
}