using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Data;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Implementation;

namespace ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation
{
    public class AppMainMenuState : AppBaseState
    {
        private readonly IUIPanelsModule _panelsModule = null;

        public AppMainMenuState(IUIPanelsModule panelsModule)
        {
            _panelsModule = panelsModule;
        }

        public override void Enter()
        {
            base.Enter();
            
            _panelsModule.ShowPanel<LoadingScreenPanel>(UIPanelType.Loading, 
                onPanelClosedAction: () 
                    => _panelsModule.ShowPanel<MainMenuPanel>(UIPanelType.Menu));
        }
    }
}