using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.Modules.UIPanels.Models;

namespace ShootArena.Infrastructure.Modules.UIPanels.Container
{
    public interface IUIPanelsContainer
    {
        void Initialize();
        public IPanelConfigModel GetPanelConfig(UIPanelType type);
    }
}