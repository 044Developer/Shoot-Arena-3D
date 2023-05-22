using ShootArena.Infrastructure.Core.Builders.Level;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Implementation;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Player.Implementation;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.EnemySpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn;
using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.Factory;
using ShootArena.Infrastructure.Core.Services.Factory.implementation;
using ShootArena.Infrastructure.Core.Services.Initialize;
using ShootArena.Infrastructure.Core.Services.Initialize.Implementation;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using ShootArena.Infrastructure.Core.Services.LevelTimer.Implementation;
using ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation;
using ShootArena.Infrastructure.Core.Services.OutOfBounds;
using ShootArena.Infrastructure.Core.Services.OutOfBounds.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerControl;
using ShootArena.Infrastructure.Core.Services.PlayerControl.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerDie;
using ShootArena.Infrastructure.Core.Services.PlayerDie.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerHealth;
using ShootArena.Infrastructure.Core.Services.PlayerHealth.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerInput;
using ShootArena.Infrastructure.Core.Services.PlayerInput.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerSetUp;
using ShootArena.Infrastructure.Core.Services.PlayerSetUp.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerShoot;
using ShootArena.Infrastructure.Core.Services.PlayerShoot.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using ShootArena.Infrastructure.Core.Services.SpawnPosition.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Core;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Scene
{
    public class CoreSceneInstaller: MonoInstaller
    {
        [Header("Environment")]
        [SerializeField] private Transform _worldSpawnPoint = null;

        [Header("Prefabs")]
        [SerializeField] private CorePrefabsContainer _prefabsContainer = null;

        public override void InstallBindings()
        {
            BindLevelEnvironment();
            
            BindModels();

            BindRuntimeData();
            
            BindFactories();
            
            BindServices();

            Container.BindInterfacesTo<LevelBuilder>().AsSingle();
        }

        

        #region Level Environment

        private void BindLevelEnvironment()
        {
            BindDynamicPrefabFacade();
        }
        
        private void BindDynamicPrefabFacade()
        {
            Container
                .Bind<IDynamicPrefabFacade>()
                .To<DynamicPrefabsFacade>()
                .FromComponentInNewPrefab(_prefabsContainer.DynamicPrefabsFacade)
                .UnderTransform(_worldSpawnPoint)
                .AsSingle()
                .NonLazy();
        }

        #endregion

        #region Models

        private void BindModels()
        {
            BindLevelModel();
        }

        private void BindLevelModel()
        {
            Container
                .Bind<ILevelConfigDataModel>()
                .To<LevelConfigDataModel>()
                .AsSingle();
        }

        #endregion

        #region RuntimeData

        private void BindRuntimeData()
        {
            BindTimersRuntimeData();

            BindLevelEnemiesRuntimeData();

            BindPlayerRuntimeData();

            BindAreaRuntimeData();
        }

        private void BindTimersRuntimeData()
        {
            Container
                .Bind<ILevelTimingRuntimeData>()
                .To<LevelTimingRuntimeData>()
                .AsSingle();
        }

        private void BindLevelEnemiesRuntimeData()
        {
            Container
                .Bind<ILevelEnemiesRuntimeData>()
                .To<LevelEnemiesRuntimeData>()
                .AsSingle();
        }

        private void BindPlayerRuntimeData()
        {
            Container
                .Bind<IPlayerRuntimeData>()
                .To<PlayerRuntimeData>()
                .AsSingle();
        }

        private void BindAreaRuntimeData()
        {
            Container
                .Bind<ILevelAreaRuntimeData>()
                .To<LevelAreaRuntimeData>()
                .AsSingle();
        }

        #endregion

        #region Factories
        
        private void BindFactories()
        {
            BindArenaFactory();

            BindPlayerFactory();
            
            BindMeleeEnemyFactory();
            
            BindRangeEnemyFactory();
        }

        private void BindArenaFactory()
        {
            Container
                .BindFactory<ArenaFacade, ArenaFacade.Factory>()
                .FromComponentInNewPrefab(_prefabsContainer.ArenaFacade)
                .AsSingle();
        }

        private void BindPlayerFactory()
        {
            Container
                .BindFactory<PlayerFacade, PlayerFacade.Factory>()
                .FromComponentInNewPrefab(_prefabsContainer.PlayerFacade)
                .AsSingle();
        }

        private void BindMeleeEnemyFactory()
        {
            Container
                .BindFactory<IEnemyConfigurationData, MeleeEnemyFacade, MeleeEnemyFacade.Factory>()
                .FromComponentInNewPrefab(_prefabsContainer.MeleeEnemyFacade)
                .AsSingle();
        }

        private void BindRangeEnemyFactory()
        {
            Container
                .BindFactory<IEnemyConfigurationData, RangeEnemyFacade, RangeEnemyFacade.Factory>()
                .FromComponentInNewPrefab(_prefabsContainer.RangedEnemyFacade)
                .AsSingle();
        }
        

        #endregion

        #region Services

        private void BindServices()
        {
            LevelTimerService();
            
            BindSpawnPositionService();
            
            BindLevelInitializeService();
            
            BindEnemyFactoryService();

            BindEnvironmentSpawnService();
            
            BindEnemySpawnService();

            BindOutOfBoundsService();

            BindPlayerSetUpService();
            
            BindPlayerInputService();

            BindPlayerControllService();

            BindPlayerSpawnService();

            BindPlayerDieService();

            BindPlayerShootService();

            BindPlayerHealthService();
            
            BindLevelUpdateService();
        }

        private void LevelTimerService()
        {
            Container
                .Bind<ILevelTimerService>()
                .To<LevelTimerService>()
                .AsSingle();
        }

        private void BindSpawnPositionService()
        {
            Container
                .Bind<ISpawnPositionService>()
                .To<SpawnPositionService>()
                .AsSingle();
        }

        private void BindLevelInitializeService()
        {
            Container
                .Bind<ILevelInitializeService>()
                .To<LevelInitializeService>()
                .AsSingle();
        }

        private void BindEnemyFactoryService()
        {
            Container
                .Bind<IEnemyFactoryService>()
                .To<EnemyFactoryService>()
                .AsSingle();
        }

        private void BindEnvironmentSpawnService()
        {
            Container
                .Bind<IEnvironmentSpawnService>()
                .To<EnvironmentSpawnService>()
                .AsSingle();
        }
        
        private void BindPlayerSetUpService()
        {
            Container
                .Bind<IPlayerSetUpService>()
                .To<PlayerSetUpService>()
                .AsSingle();
        }

        private void BindEnemySpawnService()
        {
            Container
                .Bind<IEnemySpawnService>()
                .To<EnemySpawnService>()
                .AsSingle();
        }

        private void BindPlayerHealthService()
        {
            Container
                .Bind<IPlayerHealthService>()
                .To<PlayerHealthService>()
                .AsSingle();
        }

        private void BindPlayerShootService()
        {
            Container
                .Bind<IPlayerShootService>()
                .To<PlayerShootService>()
                .AsSingle();
        }

        private void BindPlayerDieService()
        {
            Container
                .Bind<IPlayerDieService>()
                .To<PlayerDieService>()
                .AsSingle();
        }

        private void BindPlayerSpawnService()
        {
            Container
                .Bind<IPlayerSpawnService>()
                .To<PlayerSpawnService>()
                .AsSingle();
        }

        private void BindPlayerInputService()
        {
            Container
                .Bind<IPlayerMobileInputService>()
                .To<PlayerMobileInputService>()
                .AsSingle();
            
            Container
                .Bind<IPlayerStandaloneInputService>()
                .To<PlayerStandaloneInputService>()
                .AsSingle();
        }

        private void BindPlayerControllService()
        {
            Container
                .Bind<IPlayerControlService>()
                .To<PlayerControlService>()
                .AsSingle();
        }

        private void BindOutOfBoundsService()
        {
            Container
                .Bind<IOutOfBoundsService>()
                .To<OutOfBoundsService>()
                .AsSingle();
        }
        
        private void BindLevelUpdateService()
        {
            Container
                .BindInterfacesAndSelfTo<LevelUpdateService>()
                .AsSingle();
        }

        #endregion
    }
}