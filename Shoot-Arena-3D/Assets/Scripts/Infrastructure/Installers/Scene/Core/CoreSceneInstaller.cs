using System;
using ShootArena.Infrastructure.Core.Bullet.Data.Configuration;
using ShootArena.Infrastructure.Core.Bullet.Implementation;
using ShootArena.Infrastructure.Core.ControlFlow;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Implementation;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.Implementation;
using ShootArena.Infrastructure.Core.Level.Handlers.LevelStates.States.Implementation;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Player.Handlers.OutOfBounds;
using ShootArena.Infrastructure.Core.Player.Handlers.OutOfBounds.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerControl;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerControl.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerDie.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerShoot;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerShoot.Implementation;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt.Implementation;
using ShootArena.Infrastructure.Core.Player.Implementation;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.BulletSpawn;
using ShootArena.Infrastructure.Core.Services.BulletSpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry.Implementation;
using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.EnemySpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn;
using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.Initialize;
using ShootArena.Infrastructure.Core.Services.Initialize.Implementation;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using ShootArena.Infrastructure.Core.Services.LevelTimer.Implementation;
using ShootArena.Infrastructure.Core.Services.LevelUpdate.Implementation;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn;
using ShootArena.Infrastructure.Core.Services.PlayerSpawn.Implementation;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using ShootArena.Infrastructure.Core.Services.SpawnPosition.Implementation;
using ShootArena.Infrastructure.Installers.MemoryPool;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Core;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Scene.Core
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

            BindHandlers();
            
            BindLevelStateHandler();

            BindLevelStates();

            Container.BindInterfacesTo<LevelInitializer>().AsSingle();
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

            BindPlayerRuntimeData();

            BindAreaRuntimeData();

            BindLevelControlFlowRuntimeData();
        }

        private void BindTimersRuntimeData()
        {
            Container
                .Bind<ILevelTimingRuntimeData>()
                .To<LevelTimingRuntimeData>()
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

        private void BindLevelControlFlowRuntimeData()
        {
            Container
                .Bind<LevelControlFlowRuntimeData>()
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
            
            BindPlayerBulletFactory();
            
            BindEnemyBulletFactory();
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
                .BindFactory<IEnemyConfigurationData, Vector3, Transform, MeleeEnemyFacade, MeleeEnemyFacade.Factory>()
                .FromPoolableMemoryPool<IEnemyConfigurationData, Vector3, Transform, MeleeEnemyFacade, MeleeFacadePool>(poolBinder => poolBinder
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<EnemyInstaller>(_prefabsContainer.MeleeEnemyFacade));
        }

        private void BindRangeEnemyFactory()
        {
            Container
                .BindFactory<IEnemyConfigurationData, Vector3, Transform, RangeEnemyFacade, RangeEnemyFacade.Factory>()
                .FromPoolableMemoryPool<IEnemyConfigurationData, Vector3, Transform, RangeEnemyFacade, RangeEnemyFacadePool>(poolBinder => poolBinder
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<EnemyInstaller>(_prefabsContainer.RangedEnemyFacade));
        }

        private void BindPlayerBulletFactory()
        {
            Container
                .BindFactory<IBulletConfigurationData, Vector3, Vector3, PlayerBulletFacade, PlayerBulletFacade.Factory>()
                .FromPoolableMemoryPool<IBulletConfigurationData, Vector3, Vector3, PlayerBulletFacade, PlayerBulletFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(20)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<BulletInstaller>(_prefabsContainer.PlayerBullet)
                    .UnderTransformGroup("Bullets"));
        }

        private void BindEnemyBulletFactory()
        {
            Container
                .BindFactory<IBulletConfigurationData, Vector3, EnemyBulletFacade, EnemyBulletFacade.Factory>()
                .FromPoolableMemoryPool<IBulletConfigurationData, Vector3, EnemyBulletFacade, EnemyBulletFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(20)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<BulletInstaller>(_prefabsContainer.EnemyBullet)
                    .UnderTransformGroup("Bullets"));
        }
        
        class MeleeFacadePool : MonoPoolableMemoryPool<IEnemyConfigurationData, Vector3, Transform, IMemoryPool, MeleeEnemyFacade>
        {
        }
        
        class RangeEnemyFacadePool : MonoPoolableMemoryPool<IEnemyConfigurationData, Vector3, Transform, IMemoryPool, RangeEnemyFacade>
        {
        }

        class PlayerBulletFacadePool : MonoPoolableMemoryPool<IBulletConfigurationData, Vector3, Vector3, IMemoryPool, PlayerBulletFacade>
        {
        }

        class EnemyBulletFacadePool : MonoPoolableMemoryPool<IBulletConfigurationData, Vector3, IMemoryPool, EnemyBulletFacade>
        {
        }

        #endregion

        #region Services

        private void BindServices()
        {
            LevelTimerService();

            BindEnemyRegistryService();
            
            BindSpawnPositionService();
            
            BindLevelInitializeService();

            BindEnvironmentSpawnService();
            
            BindEnemySpawnService();
            
            BindLevelUpdateService();

            BindBulletSpawnService();
        }

        private void LevelTimerService()
        {
            Container
                .Bind<ILevelTimerService>()
                .To<LevelTimerService>()
                .AsSingle();
        }

        private void BindEnemyRegistryService()
        {
            Container
                .Bind<IEnemyRegistryService>()
                .To<EnemyRegistryService>()
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

        private void BindEnvironmentSpawnService()
        {
            Container
                .Bind<IEnvironmentSpawnService>()
                .To<EnvironmentSpawnService>()
                .AsSingle();
        }

        private void BindEnemySpawnService()
        {
            Container
                .Bind<IEnemySpawnService>()
                .To<EnemySpawnService>()
                .AsSingle();
        }
        
        private void BindLevelUpdateService()
        {
            Container
                .BindInterfacesAndSelfTo<LevelUpdateService>()
                .AsSingle();
        }

        private void BindBulletSpawnService()
        {
            Container
                .Bind<IBulletSpawnService>()
                .To<BulletSpawnService>()
                .AsSingle();
        }

        #endregion

        #region Handlers

        private void BindHandlers()
        {
            BindOutOfBoundsHandler();

            BindPlayerSetUpHandler();
            
            BindPlayerInputHandler();

            BindPlayerControlHandler();

            BindPlayerSpawnHandler();

            BindPlayerDieHandler();

            BindPlayerShootHandler();

            BindPlayerHealthHandler();

            BindPlayerUltHandler();
        }

        private void BindPlayerSetUpHandler()
        {
            Container
                .Bind<IPlayerSetUpHandler>()
                .To<PlayerSetUpHandler>()
                .AsSingle();
        }

        private void BindPlayerShootHandler()
        {
            Container
                .Bind<IPlayerShootHandler>()
                .To<PlayerShootHandler>()
                .AsSingle();
        }

        private void BindPlayerDieHandler()
        {
            Container
                .Bind<IPlayerDieHandler>()
                .To<PlayerDieHandler>()
                .AsSingle();
        }

        private void BindPlayerSpawnHandler()
        {
            Container
                .Bind<IPlayerSpawnService>()
                .To<PlayerSpawnService>()
                .AsSingle();
        }

        private void BindPlayerInputHandler()
        {
            Container
                .Bind<IPlayerMobileInputHandler>()
                .To<PlayerMobileInputHandler>()
                .AsSingle();
            
            Container
                .Bind<IPlayerStandaloneInputHandler>()
                .To<PlayerStandaloneInputHandler>()
                .AsSingle();
        }

        private void BindPlayerControlHandler()
        {
            Container
                .Bind<IPlayerControlHandler>()
                .To<PlayerControlHandler>()
                .AsSingle();
        }

        private void BindOutOfBoundsHandler()
        {
            Container
                .Bind<IOutOfBoundsHandler>()
                .To<OutOfBoundsHandler>()
                .AsSingle();
        }

        private void BindPlayerHealthHandler()
        {
            Container
                .Bind<IPlayerHealthHandler>()
                .To<PlayerHealthHandler>()
                .AsSingle();
        }

        private void BindPlayerUltHandler()
        {
            Container
                .Bind<IPlayerUltHandler>()
                .To<PlayerUltHandler>()
                .AsSingle();
        }

        #endregion

        #region Level States

        private void BindLevelStateHandler()
        {
            Container
                .Bind<ILevelStatesHandler>()
                .To<LevelStateHandler>()
                .AsSingle();
        }

        private void BindLevelStates()
        {
            Container
                .Bind<PrepareLevelState>()
                .AsSingle();
            
            Container
                .Bind<LevelEnterState>()
                .AsSingle();
            
            Container
                .Bind<LevelPauseState>()
                .AsSingle();
            
            Container
                .Bind<LevelResumeState>()
                .AsSingle();
            
            Container
                .Bind<LevelExitState>()
                .AsSingle();
            
            Container
                .Bind<LevelRestartState>()
                .AsSingle();
        }

        #endregion
    }
}