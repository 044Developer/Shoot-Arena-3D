using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Control;
using ShootArena.Infrastructure.Core.Enemies.Data.Damage;
using ShootArena.Infrastructure.Core.Enemies.Data.Health;
using ShootArena.Infrastructure.Core.Enemies.Data.Types;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealth;
using ShootArena.Infrastructure.Core.Enemies.Handlers.EnemyHealthBar;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Enemies.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyView _enemyView = null;

        public EnemyType EnemyType { get; private set; }
        public IEnemyView EnemyView => _enemyView;

        protected IEnemyConfigurationData enemyConfiguration = null;
        protected EnemyRuntimeData runtimeData = null;
        protected IMemoryPool enemyPool = null;
        protected IEnemyHealthHandler enemyHealthHandler = null;
        protected IEnemyHealthBarHandler healthBarHandler = null;

        public void ReceiveDamage(float damageValue)
        {
            enemyHealthHandler.ReceiveDamage(damageValue);
            healthBarHandler.UpdateHealthBar();
        }

        public void Die()
        {
            enemyPool.Despawn(this);
        }
        
        protected void SetUpEnemy(Vector3 spawnPosition, Transform parent)
        {
            EnemyType = enemyConfiguration.EnemyType;
            EnemyView.EnemyTransform.position = spawnPosition;
            EnemyView.EnemyTransform.parent = parent;
            runtimeData.Enemy = this;
            
            EnemyView.NavMeshAgent.enabled = true;
            EnemyView.NavMeshAgent.speed = enemyConfiguration.EnemyMoveSpeed;
            EnemyView.NavMeshAgent.stoppingDistance = enemyConfiguration.EnemyAttackRangeValue;

            SetUpHealthData();

            SetUpDamageData();

            SetUpControlData();
            
            healthBarHandler.UpdateHealthBar();
        }

        protected void DisposeEnemy()
        {
            EnemyView.NavMeshAgent.enabled = false;
        }

        private void SetUpHealthData()
        {
            runtimeData.EnemyHealthData = new EnemyHealthData(enemyConfiguration.EnemyMaxHealth);
        }

        private void SetUpDamageData()
        {
            runtimeData.EnemyDamageData = new EnemyDamageData(enemyConfiguration.AttackType, enemyConfiguration.EnemyAttackSpeed,
                enemyConfiguration.EnemyDealDamageValue, enemyConfiguration.PointPerEnemyValue,
                enemyConfiguration.EnemyAttackIntervalValue, enemyConfiguration.EnemyAttackRangeValue);
        }

        private void SetUpControlData()
        {
            runtimeData.EnemyControlData = new EnemyControlData(enemyConfiguration.EnemyType, enemyConfiguration.EnemyMoveSpeed, enemyConfiguration.EnemyJumpHeight);
        }
    }
}