using System;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.Modules.UIWindows
{
    public interface IUIWindowsModule
    {
        void Initialize();
        void ShowWindow<TWindow>(UIWindowType windowType, Action onWindowOpenAction = null, Action onWindowClosedAction = null) where TWindow : IUIView;
        void CloseWindow(UIWindowType windowType);
    }
}