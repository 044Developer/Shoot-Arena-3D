using System;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Data;

namespace ShootArena.Infrastructure.Modules.UIPanels.Models
{
    public class PanelConfigModel : IPanelConfigModel
    {
        public Action OnPanelOpenAction { get; set; }
        public Action OnPanelClosedAction { get; set; }
        public UIPanelType PanelType { get; }
        public string PrefabPath { get; }
        public UIRootType RootLayerType { get; }
        public IUIView Implementation { get; set; }

        public PanelConfigModel(UIPanelType panelType, string prefabPath, UIRootType rootLayerType)
        {
            PanelType = panelType;
            PrefabPath = prefabPath;
            RootLayerType = rootLayerType;
        }
    }
}