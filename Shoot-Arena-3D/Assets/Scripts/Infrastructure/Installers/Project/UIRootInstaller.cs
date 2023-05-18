using ShootArena.Infrastructure.MonoComponents.UI.Root;
using ShootArena.Infrastructure.MonoComponents.UI.Root.Implementation;
using Zenject;

public class UIRootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindUIRoot();
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
}