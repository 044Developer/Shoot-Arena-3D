using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Implementation;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class AppCoreGameState : AppBaseState
    {
        private readonly IUIPanelsModule _panelsModule = null;

        public AppCoreGameState(IUIPanelsModule panelsModule)
        {
            _panelsModule = panelsModule;
        }
        
        public override void Enter()
        {
            base.Enter();
            
            _panelsModule.ShowPanel<HudPanel>(UIPanelType.HUD);
        }
    }
}