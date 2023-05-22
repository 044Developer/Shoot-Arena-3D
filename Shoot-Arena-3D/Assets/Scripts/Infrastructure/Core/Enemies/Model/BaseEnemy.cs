using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        public Transform Transform => this.gameObject.transform;
        public IEnemyConfigurationData ConfigurationData { get; protected set; }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public virtual void SetPosition(Vector3 newPosition)
        {
            transform.localPosition = newPosition;
        }

        public virtual void Initialize()
        {
        }

        public virtual void ActivateEnemy()
        {
        }

        public virtual void SearchPlayer()
        {
        }

        public virtual void MoveToPlayer()
        {
        }

        public virtual void Attack()
        {
        }

        public virtual void Die()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}