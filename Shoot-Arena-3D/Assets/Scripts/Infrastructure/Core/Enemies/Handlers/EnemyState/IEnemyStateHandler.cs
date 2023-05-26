using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState
{
    public interface IEnemyStateHandler
    {
        void Tick();
        void EnterState<TState>() where TState : IEnemyState;
    }
}