using System;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;

namespace ShootArena.Infrastructure.Modules.UIPanels.Models
{
    public interface IPanelConfigModel
    {
        public Action OnPanelOpenAction { get; set; }
        public Action OnPanelClosedAction { get; set; }
        public UIPanelType PanelType { get; }
        public string PrefabPath { get; }
        public UIRootType RootLayerType { get; }
        public IUIView Implementation { get; set; }
    }
}