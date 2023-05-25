using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public interface IEnemyRuntimeData
    {
        public IEnemy Enemy { get; set; }
        public float AttackStartTime { get; set; }
    }
}