using ShootArena.Infrastructure.Modules.AppStateMachine;
using ShootArena.Infrastructure.Modules.AppStateMachine.Implementation;
using ShootArena.Infrastructure.Modules.AppStateMachine.States.Implementation;
using ShootArena.Infrastructure.Modules.AssetProvider;
using ShootArena.Infrastructure.Modules.AssetProvider.Implementation;
using ShootArena.Infrastructure.Modules.CustomFactory;
using ShootArena.Infrastructure.Modules.CustomFactory.Implementation;
using ShootArena.Infrastructure.Modules.CustomLogger;
using ShootArena.Infrastructure.Modules.CustomLogger.Implementation;
using ShootArena.Infrastructure.Modules.DeviceCheck;
using ShootArena.Infrastructure.Modules.DeviceCheck.Implementation;
using ShootArena.Infrastructure.Modules.SceneLoader;
using ShootArena.Infrastructure.Modules.SceneLoader.Implementation;
using ShootArena.Infrastructure.Modules.XMLReader;
using ShootArena.Infrastructure.Modules.XMLReader.Implementation;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner;
using ShootArena.Infrastructure.MonoComponents.CoroutineRunner.Implementation;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Project
{
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
            BindCurrentDeviceCheck();
            BindCustomLogger();
            BindCoroutineRunner();
            BindAssetProvider();
            BindCustomFactory();
            BindSceneLoader();
            BindAppStateMachine();
            BindAppStates();
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

        private void BindAppStates()
        {
            Container
                .Bind<BoostrapState>()
                .AsSingle();
            
            Container
                .Bind<SceneLoadState>()
                .AsSingle();
            
            Container
                .Bind<AppOutOfFocusState>()
                .AsSingle();
            
            Container
                .Bind<AppBackToFocusState>()
                .AsSingle();
            
            Container
                .Bind<AppMainMenuState>()
                .AsSingle();
            
            Container
                .Bind<AppCoreGameState>()
                .AsSingle();
            
            Container
                .Bind<AppQuitState>()
                .AsSingle();
        }

        private void BindXMLReader()
        {
            Container
                .Bind<IXMLReaderModule>()
                .To<XMLReaderModule>()
                .AsSingle();
        }

        private void BindCurrentDeviceCheck()
        {
            Container
                .Bind<IDeviceCheckModule>()
                .To<DeviceCheckModule>()
                .AsSingle();

        }

        #endregion
    }
}