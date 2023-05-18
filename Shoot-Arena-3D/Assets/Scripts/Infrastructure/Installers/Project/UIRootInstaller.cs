using ShootArena.Infrastructure.Modules.UIPanels;
using ShootArena.Infrastructure.Modules.UIPanels.Container;
using ShootArena.Infrastructure.Modules.UIPanels.Container.Implementation;
using ShootArena.Infrastructure.Modules.UIPanels.Implementation;
using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Implementation;
using Zenject;

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

    #endregion
    
    
}