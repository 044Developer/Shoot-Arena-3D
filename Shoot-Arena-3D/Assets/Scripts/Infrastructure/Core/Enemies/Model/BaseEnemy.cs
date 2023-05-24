using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyView _enemyView = null;
        
        public IEnemyView EnemyView => _enemyView;
        public IEnemyConfigurationData ConfigurationData { get; protected set; }
        public IMemoryPool MemoryPool { get; protected set; }

        public abstract void Die();
        
        protected void SetUpEnemy(Vector3 spawnPosition, Transform parent)
        {
            EnemyView.EnemyBody.SetActive(true);
            EnemyView.NavMeshAgent.enabled = true;
            EnemyView.EnemyTransform.position = spawnPosition;
            EnemyView.EnemyTransform.parent = parent;
            
            EnemyView.NavMeshAgent.speed = ConfigurationData.EnemyMoveSpeed;
            EnemyView.NavMeshAgent.stoppingDistance = ConfigurationData.EnemyAttackRangeValue;
        }

        protected void DisposeEnemy()
        {
            EnemyView.NavMeshAgent.enabled = false;
            EnemyView.EnemyBody.SetActive(false);
        }
    }
}