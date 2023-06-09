using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Configuration
{
    public interface IEnemyConfigurationData
    {
        public EnemyType EnemyType { get; }
        public EnemyAttackType AttackType { get; }
        public float EnemyMoveSpeed { get; }
        public float EnemyJumpHeight { get; }
        public float EnemyAttackSpeed { get; }
        public float EnemyMaxHealth { get; }
        public float EnemyDealDamageValue { get; }
        public float PointPerEnemyValue { get; }
        public float EnemyAttackIntervalValue { get; }
        public float EnemyAttackRangeValue { get; }
    }
}