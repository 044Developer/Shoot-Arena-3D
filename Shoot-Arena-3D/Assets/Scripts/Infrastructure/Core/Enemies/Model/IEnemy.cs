using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public interface IEnemy : IEnemyAttack
    {
        public Transform Transform { get; }
        public IEnemyConfigurationData ConfigurationData { get; }
        public void SetParent(Transform parent);
        public void SetPosition(Vector3 newPosition);
        public void ActivateEnemy();
    }
}