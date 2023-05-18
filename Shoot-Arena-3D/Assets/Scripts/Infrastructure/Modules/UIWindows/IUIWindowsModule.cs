using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.Modules.UIWindows
{
    public interface IUIWindowsModule
    {
        void ShowWindow<TWindow>(UIWindowType windowType) where TWindow : IUIView;
        void CloseWindow(UIWindowType windowType);
    }
}