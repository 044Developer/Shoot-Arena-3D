using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Container;
using ShootArena.Infrastructure.Modules.UIPanels.Container.Implementation;
using ShootArena.Infrastructure.Modules.UIPanels.Implementation;
using ShootArena.Infrastructure.Modules.UIWindows;
using ShootArena.Infrastructure.Modules.UIWindows.Container;
using ShootArena.Infrastructure.Modules.UIWindows.Container.Implementation;
using ShootArena.Infrastructure.Modules.UIWindows.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Implementation;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Project
{
    public class UIRootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindUIRoot();
        
            BindUIModules();
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
    
    
    }
}