using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.View;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy
    {
        public EnemyType EnemyType { get; }
        public IEnemyView EnemyView { get; }
        void Die();
        void ReceiveDamage(float damageValue);
    }
}