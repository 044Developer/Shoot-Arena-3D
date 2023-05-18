using ShootArena.Infrastructure;
using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.Implementation;
using ShootArena.Infrastructure.Modules.AssetProvider;
using ShootArena.Infrastructure.Modules.AssetProvider.Implementation;
using ShootArena.Infrastructure.Modules.CustomFactory;
using ShootArena.Infrastructure.Modules.CustomFactory.Implementation;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.CustomLogger.Implementation;
using ShootArena.Infrastructure.Modules.SceneLoader;
using ShootArena.Infrastructure.Modules.SceneLoader.Implementation;
using ShootArena.Infrastructure.Modules.XMLReader;
using ShootArena.Infrastructure.Modules.XMLReader.Implementation;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner.Implementation;
using Zenject;

public class AppRootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindEntryPoint();
        
        BindModules();
    }

    private void BindEntryPoint()
    {
        Container
            .Bind<IGame>()
            .To<Game>()
            .AsSingle();
    }

    #region Modules

    private void BindModules()
    {
        BindCustomLogger();
        BindCoroutineRunner();
        BindAssetProvider();
        BindCustomFactory();
        BindSceneLoader();
        BindAppStateMachine();
        BindXMLReader();
    }

    private void BindCustomLogger()
    {
        Container
            .Bind<ICustomLoggerModule>()
            .To<CustomLoggerModule>()
            .AsSingle();
    }

    private void BindCoroutineRunner()
    {
        Container
            .Bind<ICoroutineRunner>()
            .To<CoroutineRunner>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();
    }

    private void BindAssetProvider()
    {
        Container
            .Bind<IAssetProviderModule>()
            .To<AssetProviderModule>()
            .AsSingle();
    }

    public void BindCustomFactory()
    {
        Container
            .Bind<ICustomFactoryModule>()
            .To<CustomFactoryModule>()
            .AsSingle();
    }

    private void BindSceneLoader()
    {
        Container
            .Bind<ISceneLoaderModule>()
            .To<SceneLoaderModule>()
            .AsSingle();
    }

    private void BindAppStateMachine()
    {
        Container
            .Bind<IAppStateMachine>()
            .To<AppStateMachine>()
            .AsSingle();
    }

    private void BindXMLReader()
    {
        Container
            .Bind<IXMLReaderModule>()
            .To<XMLReaderModule>()
            .AsSingle();
    }

    #endregion
}