using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletLifeTime;
using ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove;
using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelTimings;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletUpdate.Implementation
{
    public class BulletUpdateHandler : ITickable
    {
        private readonly IBulletMoveHandler _moveHandler = null;
        private readonly IBulletLifeTimeHandler _lifeTimeHandler = null;
        private readonly ILevelTimingRuntimeData _levelTimingRuntimeData;

        public BulletUpdateHandler(
            IBulletMoveHandler moveHandler,
            IBulletLifeTimeHandler lifeTimeHandler,
            ILevelTimingRuntimeData levelTimingRuntimeData)
        {
            _moveHandler = moveHandler;
            _lifeTimeHandler = lifeTimeHandler;
            _levelTimingRuntimeData = levelTimingRuntimeData;
        }
        
        public void Tick()
        {
            if (_levelTimingRuntimeData.IsLevelPaused)
                return;

            _moveHandler.Tick();
            
            _lifeTimeHandler.Tick();
        }
    }
}