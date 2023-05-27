using System;
using ShootArena.Infrastructure.Core.Bullet.Data.Type;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove.Implementation
{
    public class BulletMoveHandler : IBulletMoveHandler, IInitializable, IDisposable
    {
        private const float ENEMY_BULLET_FLY_HEIGHT = 0.3f;
        private const float REMAINING_BULLET_DISTANCE_OFFSET = 1.6f;
        
        private readonly IBulletRuntimeData _bulletRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        
        private Vector3 _previousTargetPosition = Vector3.zero;
        private EnemyBulletTargetType _currentEnemyBulletTargetType = EnemyBulletTargetType.Player;

        public BulletMoveHandler(IBulletRuntimeData bulletRuntimeData, IPlayerRuntimeData playerRuntimeData)
        {
            _bulletRuntimeData = bulletRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }

        public void Initialize()
        {
            Debug.Log("Bullet init");
            _playerRuntimeData.PlayerControlData.PlayerRespawnedAction += OnPlayerRespawnAction;
        }

        public void Dispose()
        {
            _playerRuntimeData.PlayerControlData.PlayerRespawnedAction -= OnPlayerRespawnAction;
        }

        public void Tick()
        {
            if (IsPlayerBullet())
            {
                MovePlayerBullet();
            }

            if (IsEnemyBullet())
            {
                MoveEnemyBullet();
            }
        }
        
        private void MovePlayerBullet()
        {
            CalculatePlayerBullet();
        }

        private void CalculatePlayerBullet()
        {
            Vector3 bulletForce = _bulletRuntimeData.DamageData.BulletDirection * _bulletRuntimeData.DamageData.BulletSpeed;

            _bulletRuntimeData.Bullet.View.Rigidbody.velocity = bulletForce;
        }

        private void MoveEnemyBullet()
        {
            Vector3 currentTargetPos = SetBulletTarget();
            
            CalculateEnemyBullet(currentTargetPos);
            
            CheckBulletDistance(currentTargetPos);
        }

        private Vector3 SetBulletTarget()
        {
            Vector3 currentTargetPos;
            currentTargetPos = _currentEnemyBulletTargetType == EnemyBulletTargetType.Player
                ? _playerRuntimeData.Player.View.Transform.position
                : _previousTargetPosition;
            return currentTargetPos;
        }

        private void CalculateEnemyBullet(Vector3 currentTargetPos)
        {
            Vector3 currentBulletPosition = Vector3.MoveTowards(
                _bulletRuntimeData.Bullet.View.Transform.position, currentTargetPos,
                _bulletRuntimeData.DamageData.BulletSpeed * Time.deltaTime);

            currentBulletPosition.y = ENEMY_BULLET_FLY_HEIGHT;

            _bulletRuntimeData.Bullet.View.Transform.LookAt(currentTargetPos);
            _bulletRuntimeData.Bullet.View.Transform.position = currentBulletPosition;
        }

        private bool IsPlayerBullet()
        {
            return _bulletRuntimeData.Bullet.BulletType == BulletType.Player;
        }

        private bool IsEnemyBullet()
        {
            return _bulletRuntimeData.Bullet.BulletType == BulletType.Enemy;
        }

        private void OnPlayerRespawnAction()
        {
            _currentEnemyBulletTargetType = EnemyBulletTargetType.LastPlayerPosition;
            
            _previousTargetPosition = _playerRuntimeData.Player.View.Transform.position;
        }

        private void CheckBulletDistance(Vector3 currentTargetPos)
        {
            if (_currentEnemyBulletTargetType != EnemyBulletTargetType.LastPlayerPosition)
                return;
            
            float remainingDistance =
                Vector3.Distance(_bulletRuntimeData.Bullet.View.Transform.position, currentTargetPos);

            if (remainingDistance <= REMAINING_BULLET_DISTANCE_OFFSET)
            {
                _currentEnemyBulletTargetType = EnemyBulletTargetType.Player;
                
                _bulletRuntimeData.Bullet.DestroyBullet();
            }
        }
    }
}