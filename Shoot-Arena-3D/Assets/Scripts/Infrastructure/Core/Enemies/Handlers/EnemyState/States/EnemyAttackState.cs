using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.Model;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.BulletSpawn;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyState.States
{
    public class EnemyAttackState : BaseEnemyState
    {
        private const float STRAIFE_PLAYER_OFFSET = 1f;
        private const float JUMP_HEIGHT_OFFSET = 0f;
        
        private readonly IEnemyStateHandler _enemyStateHandler = null;
        private readonly IEnemyRuntimeData _enemyRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly IBulletSpawnService _bulletSpawnService = null;

        private bool _hasJumped = false;
        private Vector3 _jumpPos = Vector3.zero;
        
        public EnemyAttackState(
            IEnemyStateHandler enemyStateHandler,
            IEnemyRuntimeData enemyRuntimeData,
            IPlayerRuntimeData playerRuntimeData,
            IBulletSpawnService bulletSpawnService
            )
        {
            _enemyStateHandler = enemyStateHandler;
            _enemyRuntimeData = enemyRuntimeData;
            _playerRuntimeData = playerRuntimeData;
            _bulletSpawnService = bulletSpawnService;
        }

        public override void Enter()
        {
            base.Enter();

            if (IsMeleeEnemyAttack())
            {
                PrepareAttack();
            }
            
            if (IsRangeEnemyAttack())
            {
                AttackRange();
            }
        }

        public override void Tick()
        {
            base.Tick();
            
            if (!IsMeleeEnemyAttack())
                return;

            AttackMelee();
        }

        private void AttackMelee()
        {
            if (!_hasJumped)
            {
                Jump();

                if (!HasJumped())
                    return;

                _hasJumped = true;
                _enemyRuntimeData.EnemyDamageData.AttackStartTime = Time.realtimeSinceStartup;
            }

            if (!IsStrafeDelayed())
                return;

            StrafeToPlayer();

            if (!HasReachedPlayer())
                return;
            
            _playerRuntimeData.Player.ReceiveDamage(_enemyRuntimeData.EnemyDamageData.DamageValue);
            _enemyStateHandler.EnterState<EnemyDieState>();
        }

        private void PrepareAttack()
        {
            _enemyRuntimeData.Enemy.EnemyView.NavMeshAgent.enabled = false;
            _hasJumped = false;
            _jumpPos =  new Vector3(_enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position.x, _enemyRuntimeData.EnemyControlData.JumpHeight, _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position.z);
        }

        private void Jump()
        {
            _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position = Vector3.MoveTowards(
                _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position, _jumpPos,
                _enemyRuntimeData.EnemyControlData.MoveSpeed * Time.deltaTime);
        }

        private bool IsStrafeDelayed()
        {
            return Time.realtimeSinceStartup - _enemyRuntimeData.EnemyDamageData.AttackStartTime > _enemyRuntimeData.EnemyDamageData.AttackInterval;
        }

        private void StrafeToPlayer()
        {
            _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position = Vector3.MoveTowards(
                _enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position, _playerRuntimeData.Player.View.Transform.position,
                _enemyRuntimeData.EnemyDamageData.AttackSpeed * Time.deltaTime);
        }

        private bool HasJumped()
        {
            float remainingDistance =
                Vector3.Distance(_enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position, _jumpPos);
            return remainingDistance <= JUMP_HEIGHT_OFFSET;
        }

        private bool HasReachedPlayer()
        {
            return Vector3.Distance(_enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position, _playerRuntimeData.Player.View.Transform.position) <= STRAIFE_PLAYER_OFFSET;
        }

        private void AttackRange()
        {
            _bulletSpawnService.SpawnEnemyBullet(_enemyRuntimeData.Enemy.EnemyView.EnemyTransform.position);
            _enemyStateHandler.EnterState<EnemyRechargeState>();
        }

        private bool IsMeleeEnemyAttack() => 
            _enemyRuntimeData.EnemyDamageData.AttackType == EnemyAttackType.Physical;
        private bool IsRangeEnemyAttack() => 
            _enemyRuntimeData.EnemyDamageData.AttackType == EnemyAttackType.Shooting;
    }
}