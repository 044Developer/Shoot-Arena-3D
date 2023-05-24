using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState
{
    public interface IEnemyStateService
    {
        void EnterState<TState>() where TState : IEnemyState;
    }
}