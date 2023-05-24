using System.Collections;
using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyRegistry
{
    public interface IEnemyRegistryService
    {
        IEnumerable<IEnemy> AllEnemies { get; }
        IEnumerable<IEnemy> RangedEnemies { get; }
        IEnumerable<IEnemy> MeleeEnemies { get; }
        int TotalEnemiesCount { get; }
        int TotalMeleeCount { get; }
        int TotalRangedCount { get; }
        void AddEnemy(IEnemy enemy);
        void RemoveEnemy(IEnemy enemy);
    }
}