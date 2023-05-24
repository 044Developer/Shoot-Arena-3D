using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public interface IEnemyRuntimeData
    {
        public IEnemy Enemy { get; set; }
    }
}