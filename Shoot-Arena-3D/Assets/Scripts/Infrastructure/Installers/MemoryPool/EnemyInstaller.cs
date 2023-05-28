using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyUpdater.Implementation;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Installers.MemoryPool
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            BindData();

            BindHealthHandler();

            BindHealthBarHandler();
            
            BindStateService();

            BindStates();

            BindEnemyUpdaterHandler();
        }

        private void BindData()
        {
            Container
                .Bind<IEnemyRuntimeData>()
                .To<EnemyRuntimeData>()
                .AsSingle();
        }

        private void BindHealthHandler()
        {
            Container
                .Bind<IEnemyHealthHandler>()
                .To<EnemyHealthHandler>()
                .AsSingle();
        }

        private void BindHealthBarHandler()
        {
            Container
                .Bind<IEnemyHealthBarHandler>()
                .To<EnemyHealthBarHandler>()
                .AsSingle();
        }

        private void BindStateService()
        {
            Container
                .Bind<IEnemyStateHandler>()
                .To<EnemyStateHandler>()
                .AsSingle()
                .Lazy();
        }

        private void BindStates()
        {
            Container
                .Bind<EnemyIdleState>()
                .AsSingle();
            
            Container
                .Bind<EnemyMoveToState>()
                .AsSingle();
            
            Container
                .Bind<EnemyPrepareAttackState>()
                .AsSingle();
            
            Container
                .Bind<EnemyAttackState>()
                .AsSingle();
            
            Container
                .Bind<EnemyRechargeState>()
                .AsSingle();
            
            Container
                .Bind<EnemyDieState>()
                .AsSingle();
            
        }

        private void BindEnemyUpdaterHandler()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyUpdaterHandler>()
                .AsSingle();
        }
    }
}