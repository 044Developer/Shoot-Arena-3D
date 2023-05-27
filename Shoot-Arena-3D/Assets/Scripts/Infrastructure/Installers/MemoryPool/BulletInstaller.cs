using System;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletLifeTime;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletLifeTime.Implementation;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove.Implementation;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletUpdate.Implementation;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using Zenject;

namespace ShootArena.Infrastructure.Installers.MemoryPool
{
    public class BulletInstaller : Installer<BulletInstaller>
    {
        public override void InstallBindings()
        {
            BindData();

            BindHandlers();
        }

        private void BindData()
        {
            Container
                .Bind<IBulletRuntimeData>()
                .To<BulletRuntimeData>()
                .AsSingle();
        }

        private void BindHandlers()
        {
            BindMoveHandler();

            BindLifeTimeHandler();

            BindBulletUpdateHandler();
        }

        private void BindMoveHandler()
        {
            Container
                .Bind(typeof(IBulletMoveHandler), typeof(IInitializable), typeof(IDisposable))
                .To<BulletMoveHandler>()
                .AsSingle();
        }

        private void BindLifeTimeHandler()
        {
            Container
                .Bind<IBulletLifeTimeHandler>()
                .To<BulletLifeTimeHandler>()
                .AsSingle();
        }

        private void BindBulletUpdateHandler()
        {
            Container
                .BindInterfacesAndSelfTo<BulletUpdateHandler>()
                .AsSingle();
        }
    }
}