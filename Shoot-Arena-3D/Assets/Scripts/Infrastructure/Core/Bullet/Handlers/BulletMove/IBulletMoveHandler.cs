namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove
{
    public interface IBulletMoveHandler
    {
        void LaunchPlayerBullet();
        void Tick();
    }
}