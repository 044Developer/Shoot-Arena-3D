using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Configuration
{
    public class EnemyConfigurationData : IEnemyConfigurationData
    {
        public EnemyType EnemyType { get; }
        public EnemyAttackType AttackType { get; }
        public float EnemyMoveSpeed { get; }
        public float EnemyMaxHealth { get; }
        public float EnemyDealDamageValue { get; }
        public float PointPerEnemyValue { get; }
        public float EnemyAttackIntervalValue { get; }
        public float EnemyAttackRangeValue { get; }

        public EnemyConfigurationData(
            EnemyType enemyType,
            EnemyAttackType attackType,
            float enemyMoveSpeed,
            float enemyMaxHealth,
            float enemyDealDamageValue,
            float pointPerEnemyValue,
            float enemyAttackIntervalValue,
            float enemyAttackRangeValue)
        {
            EnemyType = enemyType;
            AttackType = attackType;
            EnemyMoveSpeed = enemyMoveSpeed;
            EnemyMaxHealth = enemyMaxHealth;
            EnemyDealDamageValue = enemyDealDamageValue;
            PointPerEnemyValue = pointPerEnemyValue;
            EnemyAttackIntervalValue = enemyAttackIntervalValue;
            EnemyAttackRangeValue = enemyAttackRangeValue;
        }
    }
}