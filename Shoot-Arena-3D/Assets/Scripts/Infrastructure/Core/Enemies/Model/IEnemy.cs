using ShootArena.Infrastructure.Core.Enemies.Data.Control;
using ShootArena.Infrastructure.Core.Enemies.Data.Damage;
using ShootArena.Infrastructure.Core.Enemies.Data.Health;
using ShootArena.Infrastructure.Core.Enemies.View;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy
    {
        public IEnemyView EnemyView { get; }
        public IEnemyHealthData HealthData { get; }
        public IEnemyDamageData DamageData { get; }
        public IEnemyControlData ControlData { get; }
        void Die();
    }
}