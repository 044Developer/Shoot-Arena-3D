using ShootArena.Infrastructure.Core.Services.EnemyState.Model;
using Zenject;

namespace ShootArena.Infrastructure.Core.Services.EnemyState
{
    public interface IEnemyStateService : ITickable
    {
        void EnterState<TState>() where TState : IEnemyState;
    }
}