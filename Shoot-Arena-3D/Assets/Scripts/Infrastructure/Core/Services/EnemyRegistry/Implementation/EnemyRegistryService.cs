﻿using System.Collections.Generic;
using System.Linq;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyRegistry.Implementation
{
    public class EnemyRegistryService : IEnemyRegistryService
    {
        private protected Dictionary<EnemyType, List<IEnemy>> _enemiesByType = null;
        private protected List<IEnemy> _allEnemies = null;

        public IEnumerable<IEnemy> AllEnemies => _allEnemies;
        public IEnumerable<IEnemy> MeleeEnemies => _enemiesByType[EnemyType.MeleeEnemy];
        public IEnumerable<IEnemy> RangedEnemies => _enemiesByType[EnemyType.RangeEnemy];
        public int TotalEnemiesCount => MeleeEnemies.Count() + RangedEnemies.Count();
        public int TotalMeleeCount => MeleeEnemies.Count();
        public int TotalRangedCount => RangedEnemies.Count();

        public EnemyRegistryService()
        {
            _allEnemies = new List<IEnemy>();
            _enemiesByType = new Dictionary<EnemyType, List<IEnemy>>
            {
                [EnemyType.MeleeEnemy] = new List<IEnemy>(),
                [EnemyType.RangeEnemy] = new List<IEnemy>()
            };
        }

        public void AddEnemy(IEnemy enemy)
        {
            _allEnemies.Add(enemy);
            _enemiesByType[enemy.ControlData.EnemyType].Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            _allEnemies.Remove(enemy);
            _enemiesByType[enemy.ControlData.EnemyType].Remove(enemy);
        }
    }
}