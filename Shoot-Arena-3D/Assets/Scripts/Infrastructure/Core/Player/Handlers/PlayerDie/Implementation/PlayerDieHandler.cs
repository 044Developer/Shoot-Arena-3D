using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie.Implementation
{
    public class PlayerDieHandler : IPlayerDieHandler
    {
        private readonly IUIWindowsModule _windowsModule = null;

        public PlayerDieHandler(
            IUIWindowsModule windowsModule
            )
        {
            _windowsModule = windowsModule;
        }
        
        public void Die()
        {
            _windowsModule.ShowWindow<LooseWindow>(UIWindowType.Loose);
        }
    }
}