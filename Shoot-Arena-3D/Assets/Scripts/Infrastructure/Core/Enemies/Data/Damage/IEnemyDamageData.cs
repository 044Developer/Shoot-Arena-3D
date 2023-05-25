using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Damage
{
    public interface IEnemyDamageData
    {
        public EnemyAttackType AttackType { get; }
        public float AttackSpeed { get; }
        public float DamageValue { get; }
        public float RewardPoints { get; }
        public float AttackInterval { get; }
        public float AttackRange { get; }
    }
}