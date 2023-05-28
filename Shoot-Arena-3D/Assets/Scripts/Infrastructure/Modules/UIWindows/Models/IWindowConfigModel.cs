using System;
using ShootArena.Infrastructure.Modules.UIWindows.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;

namespace ShootArena.Infrastructure.Modules.UIWindows.Models
{
    public interface IWindowConfigModel
    {
        public Action OnWindowOpenAction { get; set; }
        public Action OnWindowCloseAction { get; set; }
        public UIWindowType WindowType { get; }
        public string PrefabPath { get; }
        public UIRootType RootLayerType { get; }
        public IUIView Implementation { get; set; }
    }
}