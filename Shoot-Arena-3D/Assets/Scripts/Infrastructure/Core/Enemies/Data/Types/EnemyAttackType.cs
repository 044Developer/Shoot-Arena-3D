using System;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Types
{
    [Flags]
    public enum EnemyAttackType
    {
        None = 0,
        Shooting = 1 << 0,
        Physical = 1 << 1,
    }
}