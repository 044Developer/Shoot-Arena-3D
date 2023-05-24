using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState;
using ShootArena.Infrastructure.Core.Services.EnemyState.Implementation;
using ShootArena.Infrastructure.Core.Services.EnemyState.States;
using Zenject;

namespace ShootArena.Infrastructure.Installers.MemoryPool
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            BindData();

            BindStateService();

            BindStates();
        }

        private void BindData()
        {
            Container
                .Bind<IEnemyRuntimeData>()
                .To<EnemyRuntimeData>()
                .AsSingle();
        }

        private void BindStateService()
        {
            Container
                .Bind(typeof(IEnemyStateService), typeof(ITickable))
                .To<EnemyStateService>()
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
    }
}