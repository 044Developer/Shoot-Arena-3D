using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.Modules.UIWindows.Models;

namespace ShootArena.Infrastructure.Modules.UIWindows.Container
{
    public interface IUIWindowsContainer
    {
        public IWindowConfigModel GetWindowConfig(UIWindowType type);
    }
}