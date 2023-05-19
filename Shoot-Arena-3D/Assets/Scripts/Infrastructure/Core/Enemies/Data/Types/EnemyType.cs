using System;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Types
{
    [Flags]
    public enum EnemyType
    {
        None = 0,
        MeleeEnemy = 1 << 0,
        RangeEnemy = 1 << 1,
    }
}