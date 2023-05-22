using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData
{
    public interface ILevelEnemiesRuntimeData
    {
        public int TotalActiveMeleeEnemiesCount { get; set; }
        public int TotalActiveRangeEnemiesCount { get; set; }
        public List<IEnemy> AllActiveEnemies { get; set; } 
    }
}