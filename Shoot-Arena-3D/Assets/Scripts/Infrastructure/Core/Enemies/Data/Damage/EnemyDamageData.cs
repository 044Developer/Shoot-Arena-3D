using ShootArena.Infrastructure.Core.Enemies.Data.Types;

namespace ShootArena.Infrastructure.Core.Enemies.Data.Damage
{
    public class EnemyDamageData
    {
        public EnemyAttackType AttackType { get; }
        public float AttackSpeed { get; }
        public float DamageValue { get; }
        public float RewardPoints { get; }
        public float AttackInterval { get; }
        public float AttackRange { get; }
        public float AttackStartTime { get; set; }

        public EnemyDamageData(EnemyAttackType attackType, float attackSpeed, float damageValue, float rewardPoints, float attackInterval, float attackRange)
        {
            AttackType = attackType;
            AttackSpeed = attackSpeed;
            DamageValue = damageValue;
            RewardPoints = rewardPoints;
            AttackInterval = attackInterval;
            AttackRange = attackRange;
        }
    }
}