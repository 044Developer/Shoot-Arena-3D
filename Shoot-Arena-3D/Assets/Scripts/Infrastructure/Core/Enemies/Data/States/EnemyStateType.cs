namespace ShootArena.Infrastructure.Core.Enemies.Data.States
{
    public enum EnemyStateType
    {
        None,
        SearchState,
        MoveToState,
        TargetReached,
        PrepareAttackState,
        AttackState,
        RechargeState,
        DieState
    }
}