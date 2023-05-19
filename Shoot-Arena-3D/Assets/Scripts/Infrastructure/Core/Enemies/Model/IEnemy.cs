using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy
    {
        public IEnemyConfigurationData ConfigurationData { get; }
        public void SetPosition(Vector3 newPosition);
        public void Initialize();
        public void ActivateEnemy();
        public void SearchPlayer();
        public void MoveToPlayer();
        public void Attack();
        public void Die();
        public void Dispose();
    }
}