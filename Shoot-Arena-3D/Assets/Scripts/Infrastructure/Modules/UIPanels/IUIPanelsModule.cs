using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Base;

namespace ShootArena.Infrastructure.Modules.UIPanels
{
    public interface IUIPanelsModule
    {
        void ShowPanel<TPanel>(UIPanelType panelType) where TPanel : IUIView;
        void ClosePanel(UIPanelType panelType);
    }
}