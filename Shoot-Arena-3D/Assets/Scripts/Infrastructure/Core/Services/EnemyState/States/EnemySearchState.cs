using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyState.Model;

namespace ShootArena.Infrastructure.Core.Services.EnemyState.States
{
    public class EnemySearchState : BaseEnemyState
    {
        private readonly IEnemyStateService _enemyStateService = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;

        public EnemySearchState(
            IEnemyStateService enemyStateService,
            IPlayerRuntimeData playerRuntimeData,
            IEnemyRuntimeData enemyRuntimeData
            )
        {
            _enemyStateService = enemyStateService;
            _playerRuntimeData = playerRuntimeData;
            _enemyRuntimeData = enemyRuntimeData;
        }

        public override void Enter()
        {
            base.Enter();
            
            _enemyRuntimeData.Player = _playerRuntimeData.Player;
            
            _enemyStateService.EnterState<EnemyMoveToState>();
        }
    }
}