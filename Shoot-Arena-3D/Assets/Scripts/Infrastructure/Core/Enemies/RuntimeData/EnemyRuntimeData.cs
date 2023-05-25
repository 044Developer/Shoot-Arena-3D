using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public class EnemyRuntimeData : IEnemyRuntimeData
    {
        public IEnemy Enemy { get; set; }
        public float AttackStartTime { get; set; }
    }
}