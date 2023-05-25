using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.Control;
using ShootArena.Infrastructure.Core.Enemies.Data.Damage;
using ShootArena.Infrastructure.Core.Enemies.Data.Health;
using ShootArena.Infrastructure.Core.Enemies.RuntimeData;
using ShootArena.Infrastructure.Core.Enemies.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyView _enemyView = null;

        public IEnemyView EnemyView => _enemyView;
        public IEnemyHealthData HealthData => _healthData;
        public IEnemyDamageData DamageData => _damageData;
        public IEnemyControlData ControlData => _controlData;

        protected IEnemyConfigurationData enemyConfiguration = null;
        protected EnemyRuntimeData runtimeData = null;
        private EnemyHealthData _healthData = null;
        private EnemyDamageData _damageData = null;
        private EnemyControlData _controlData = null;
        protected IMemoryPool enemyPool = null;

        public void Die()
        {
            enemyPool.Despawn(this);
        }
        
        protected void SetUpEnemy(Vector3 spawnPosition, Transform parent)
        {
            EnemyView.EnemyTransform.position = spawnPosition;
            EnemyView.EnemyTransform.parent = parent;
            runtimeData.Enemy = this;
            
            EnemyView.EnemyBody.SetActive(true);
            EnemyView.NavMeshAgent.enabled = true;
            EnemyView.NavMeshAgent.speed = enemyConfiguration.EnemyMoveSpeed;
            EnemyView.NavMeshAgent.stoppingDistance = enemyConfiguration.EnemyAttackRangeValue;

            SetUpHealthData();

            SetUpDamageData();

            SetUpControlData();
        }

        protected void DisposeEnemy()
        {
            EnemyView.NavMeshAgent.enabled = false;
            EnemyView.EnemyBody.SetActive(false);
        }

        private void SetUpHealthData()
        {
            _healthData = new EnemyHealthData(enemyConfiguration.EnemyMaxHealth, 0);
        }

        private void SetUpDamageData()
        {
            _damageData = new EnemyDamageData(enemyConfiguration.AttackType, enemyConfiguration.EnemyAttackSpeed,
                enemyConfiguration.EnemyDealDamageValue, enemyConfiguration.PointPerEnemyValue,
                enemyConfiguration.EnemyAttackIntervalValue, enemyConfiguration.EnemyAttackRangeValue);
        }

        private void SetUpControlData()
        {
            _controlData = new EnemyControlData(enemyConfiguration.EnemyType, enemyConfiguration.EnemyMoveSpeed, enemyConfiguration.EnemyJumpHeight);
        }
    }
}