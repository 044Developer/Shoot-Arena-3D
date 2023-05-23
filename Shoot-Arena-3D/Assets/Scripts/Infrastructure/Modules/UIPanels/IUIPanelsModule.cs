using System;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.Modules.UIPanels
{
    public interface IUIPanelsModule
    {
        void Initialize();
        void ShowPanel<TPanel>(UIPanelType panelType, Action onPanelOpenAction = null, Action onPanelClosedAction = null) where TPanel : IUIView;
        void ClosePanel(UIPanelType panelType);
    }
}