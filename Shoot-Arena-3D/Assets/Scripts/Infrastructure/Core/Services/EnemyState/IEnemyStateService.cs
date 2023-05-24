using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState
{
    public interface IEnemyStateService
    {
        void RegisterService(IEnemyRuntimeData enemyRuntimeData);
        void EnterState<TState>() where TState : IEnemyState;
    }
}