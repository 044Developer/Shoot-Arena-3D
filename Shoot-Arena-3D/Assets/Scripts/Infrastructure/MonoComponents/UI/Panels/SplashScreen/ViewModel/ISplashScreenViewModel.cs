using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.ViewModel
{
    public interface ISplashScreenViewModel : IUIViewModel
    {
        public float SplashScreenDuration { get; }
    }
}