namespace ShootArena.Infrastructure.Core.Services.EnemyState.Model
{
    public abstract class BaseEnemyState : IEnemyState
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Tick()
        {
        }
    }
}