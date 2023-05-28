namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model
{
    public interface IEnemyState
    {
        void Enter();
        void Exit();
        void Tick();
    }
}