namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemyAttack
    {
        void SearchTarget();
        void MoveToTarget();
        void CheckAttackDistance();
        void PrepareAttack();
        void Attack();
        void Recharge();
        void Die();
    }
}