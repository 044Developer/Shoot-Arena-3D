using ShootArena.Infrastructure.Core.Bullet.Data.Type;
using ShootArena.Infrastructure.Core.Bullet.RuntimeData;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Handlers.BulletMove.Implementation
{
    public class BulletMoveHandler : IBulletMoveHandler
    {
        private const float ENEMY_BULLET_FLY_HEIGHT = 0.3f;
        
        private readonly IBulletRuntimeData _bulletRuntimeData = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;

        public BulletMoveHandler(IBulletRuntimeData bulletRuntimeData, IPlayerRuntimeData playerRuntimeData)
        {
            _bulletRuntimeData = bulletRuntimeData;
            _playerRuntimeData = playerRuntimeData;
        }

        public void Tick()
        {
            LaunchPlayerBullet();
            LaunchEnemyBullet();
        }
        
        public void LaunchPlayerBullet()
        {
            if (_bulletRuntimeData.Bullet.BulletType != BulletType.Player)
                return;
            
            Vector3 bulletForce = _bulletRuntimeData.DamageData.BulletDirection * _bulletRuntimeData.DamageData.BulletSpeed;

            _bulletRuntimeData.Bullet.View.Rigidbody.velocity = bulletForce;
        }

        private void LaunchEnemyBullet()
        {
            if (_bulletRuntimeData.Bullet.BulletType != BulletType.Enemy)
                return;

            if (HasEnemyJumpedOff())
            {
                _bulletRuntimeData.Bullet.DestroyBullet();
                return;
            }
            
            Vector3 currentBulletPosition = Vector3.MoveTowards(
                _bulletRuntimeData.Bullet.View.Transform.position, _playerRuntimeData.Player.View.Transform.position,
                _bulletRuntimeData.DamageData.BulletSpeed * Time.deltaTime);

            currentBulletPosition.y = ENEMY_BULLET_FLY_HEIGHT;

            _bulletRuntimeData.Bullet.View.Transform.LookAt(_playerRuntimeData.Player.View.Transform);
            _bulletRuntimeData.Bullet.View.Transform.position = currentBulletPosition;
        }

        private bool HasEnemyJumpedOff()
        {
            return !_playerRuntimeData.Player.IsPlayerGrounded();
        }
    }
}