using ShootArena.Infrastructure.Core.Enemies.Data.Control;
using ShootArena.Infrastructure.Core.Enemies.Data.Damage;
using ShootArena.Infrastructure.Core.Enemies.Data.Health;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public interface IEnemyRuntimeData
    {
        public IEnemy Enemy { get; }
        public EnemyHealthData EnemyHealthData { get; }
        public EnemyDamageData EnemyDamageData { get; }
        public EnemyControlData EnemyControlData { get; }
    }
}