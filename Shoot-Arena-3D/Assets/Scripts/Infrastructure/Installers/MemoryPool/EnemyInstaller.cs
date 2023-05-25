﻿using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States;
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

        private void BindHealthHandler()
        {
            Container
                .Bind<IEnemyHealthHandler>()
                .To<EnemyHealthHandler>()
                .AsSingle();
        }

        private void BindStateService()
        {
            Container
                .Bind(typeof(IEnemyStateHandler), typeof(ITickable))
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
    }
}