using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletLifeTime;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletUpdate.Implementation
{
    public class BulletUpdateHandler : ITickable
    {
        private readonly IBulletMoveHandler _moveHandler = null;
        private readonly IBulletLifeTimeHandler _lifeTimeHandler = null;

        public BulletUpdateHandler(IBulletMoveHandler moveHandler, IBulletLifeTimeHandler lifeTimeHandler)
        {
            _moveHandler = moveHandler;
            _lifeTimeHandler = lifeTimeHandler;
        }
        
        public void Tick()
        {
            _moveHandler.Tick();
            
            _lifeTimeHandler.Tick();
        }
    }
}