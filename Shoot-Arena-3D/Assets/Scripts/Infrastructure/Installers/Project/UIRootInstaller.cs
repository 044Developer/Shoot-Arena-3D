using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Container;
using ShootArena.Infrastructure.Modules.UIPanels.Container.Implementation;
using ShootArena.Infrastructure.Modules.UIPanels.Implementation;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Container;
using ShootArena.Infrastructure.Modules.UIWindows.Container.Implementation;
using ShootArena.Infrastructure.Modules.UIWindows.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Project
{
    public class UIRootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindUIRoot();

            BindRuntimeData();
        
            BindUIModules();

            BindUIMediators();
        }

        private void BindUIRoot()
        {
            Container
                .Bind<IUIRoot>()
                .To<UIRoot>()
                .FromComponentInNewPrefabResource("Prefabs/UI/Root/[----UI_Root----]")
                .AsSingle()
                .NonLazy();;
        }

        #region Modules
    
        private void BindUIModules()
        {
            BindPanelsModule();
            BindWindowsModule();
        }

        private void BindPanelsModule()
        {
            Container
                .Bind<IUIPanelsContainer>()
                .To<UIPanelsContainer>()
                .AsSingle();

            Container
                .Bind<IUIPanelsModule>()
                .To<UIPanelsModule>()
                .AsSingle();
        }

        private void BindWindowsModule()
        {
            Container
                .Bind<IUIWindowsContainer>()
                .To<UIWindowsContainer>()
                .AsSingle();

            Container
                .Bind<IUIWindowsModule>()
                .To<UIWindowsModule>()
                .AsSingle();
        }

        #endregion

        #region Mediators

        private void BindUIMediators()
        {
            BindPanelMediators();
            
            BindWindowMediators();
        }

        private void BindPanelMediators()
        {
            BindSplashPanelMediator();
            BindLoadingScreenMediator();
            BindMainMenuMediator();
            BindHudMediator();
        }

        private void BindSplashPanelMediator()
        {
            Container
                .Bind<ISplashScreenMediator>()
                .To<SplashScreenMediator>()
                .AsSingle()
                .WhenInjectedInto<SplashScreenPanel>();
        }

        private void BindLoadingScreenMediator()
        {
            Container
                .Bind<ILoadingScreenMediator>()
                .To<LoadingScreenMediator>()
                .AsSingle()
                .WhenInjectedInto<LoadingScreenPanel>();
        }

        private void BindMainMenuMediator()
        {
            Container
                .Bind<IMainMenuMediator>()
                .To<MainMenuMediator>()
                .AsSingle()
                .WhenInjectedInto<MainMenuPanel>();
        }

        private void BindHudMediator()
        {
            Container
                .Bind<IHudMediator>()
                .To<HudMediator>()
                .AsSingle()
                .WhenInjectedInto<HudPanel>();
        }

        private void BindWindowMediators()
        {
            BindPauseWindowMediator();
            BindLooseWindowMediator();
            BindLevelCountDownMediator();
        }

        private void BindPauseWindowMediator()
        {
            Container
                .Bind<IPauseMediator>()
                .To<PauseMediator>()
                .AsSingle()
                .WhenInjectedInto<PauseWindow>();
        }

        private void BindLooseWindowMediator()
        {
            Container
                .Bind<ILooseMediator>()
                .To<LooseMediator>()
                .AsSingle()
                .WhenInjectedInto<LooseWindow>();
        }

        private void BindLevelCountDownMediator()
        {
            Container
                .Bind<ILevelCountDownMediator>()
                .To<LevelCountDownMediator>()
                .AsSingle()
                .WhenInjectedInto<LevelCountDownWindow>();
        }

        #endregion

        #region RuntimeData

        private void BindRuntimeData()
        {
            BindHudRuntimeData();

            BindLoseLevelRuntimeData();
            
            BindPauseLevelRuntimeData();
        }

        private void BindHudRuntimeData()
        {
            Container
                .Bind<IHUDRuntimeData>()
                .To<HUDRuntimeData>()
                .AsSingle();
        }

        private void BindLoseLevelRuntimeData()
        {
            Container
                .Bind<ILevelLooseRuntimeData>()
                .To<LevelLooseRuntimeData>()
                .AsSingle();
        }

        private void BindPauseLevelRuntimeData()
        {
            Container
                .Bind<ILevelPauseRuntimeData>()
                .To<LevelPauseRuntimeData>()
                .AsSingle();
        }

        #endregion
    }
}