using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletRicochet
{
    public interface IBulletRicochetHandler
    {
        bool IsRicochetActive();
        void CalculateClosestEnemy(IEnemy damageTarget);
    }
}