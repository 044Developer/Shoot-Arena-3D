using ShootArena.Infrastructure.Core.Bullet.View;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Bullet.Model
{
    public interface IBullet
    {
        IBulletView View { get; } 
        void OnBulletHitAction(Collision collision);
        void DestroyBullet();
    }
}