using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.Model;

namespace ShootArena.Infrastructure.Core.Enemies.RuntimeData
{
    public class EnemyRuntimeData : IEnemyRuntimeData
    {
        public IPlayer Player { get; set; }
        public IEnemy Enemy { get; set; }
    }
}