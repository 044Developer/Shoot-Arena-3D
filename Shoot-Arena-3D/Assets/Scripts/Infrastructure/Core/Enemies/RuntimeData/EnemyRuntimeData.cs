using ShootArena.Infrastructure.Core.Enemies.Data.Control;
using ShootArena.Infrastructure.Core.Enemies.Data.Damage;
using ShootArena.Infrastructure.Core.Enemies.Data.Health;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public class EnemyRuntimeData : IEnemyRuntimeData
    {
        public IEnemy Enemy { get; set; }
        public EnemyHealthData EnemyHealthData { get; set; }
        public EnemyDamageData EnemyDamageData { get; set; }
        public EnemyControlData EnemyControlData { get; set; }
    }
}