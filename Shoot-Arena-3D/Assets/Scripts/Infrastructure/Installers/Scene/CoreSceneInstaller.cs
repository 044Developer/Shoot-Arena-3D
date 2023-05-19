using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Level.Model;
using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.Factory;
using ShootArena.Infrastructure.Core.Services.Initialize;
using ShootArena.Infrastructure.Core.Services.LevelTimer;
using ShootArena.Infrastructure.Core.Services.LevelUpdate;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Installers.Scene
{
    public class CoreSceneInstaller: MonoInstaller
    {
        [Header("Enemies")]
        [SerializeField] private MeleeEnemy _meleeEnemy = null;
        [SerializeField] private MeleeEnemy _rangedEnemy = null;
        
        public override void InstallBindings()
        {
            BindModels();
            
            BindFactories();
            
            BindServices();
        }

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

        #region Factories
        
        private void BindFactories()
        {
            BindMeleeEnemyFactory();
            
            BindRangeEnemyFactory();
        }

        private void BindMeleeEnemyFactory()
        {
            Container
                .BindFactory<IEnemyConfigurationData, MeleeEnemy, MeleeEnemy.Factory>()
                .FromComponentInNewPrefab(_meleeEnemy)
                .AsSingle();
        }

        private void BindRangeEnemyFactory()
        {
            Container
                .BindFactory<IEnemyConfigurationData, RangeEnemy, RangeEnemy.Factory>()
                .FromComponentInNewPrefab(_rangedEnemy)
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

            BindEnemySpawnService();

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

        #endregion
    }
}