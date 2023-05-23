using System;
using ShootArena.Infrastructure.Core.Enemies.Data.Configuration;
using ShootArena.Infrastructure.Core.Enemies.Data.States;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using UnityEngine;
using UnityEngine.AI;

namespace ShootArena.Infrastructure.Core.Enemies.Model
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private NavMeshAgent _navMeshAgent = null;
        [SerializeField] private GameObject _enemyBody = null;
        
        public Transform Transform => this.gameObject.transform;
        public IEnemyConfigurationData ConfigurationData { get; protected set; }
        
        protected IPlayerRuntimeData playerRuntime = null;

        private Action<IEnemy> _onEnemyDieAction = null;
        private EnemyStateType _currentEnemyState = EnemyStateType.None;
        private float _currentRechargeTime = 0f;

        /*
         *  Set Up Logic
         */

        public virtual void Initialize()
        {
        }

        public void SetEnemyDieAction(Action<IEnemy> onEnemyDieAction)
        {
            _onEnemyDieAction = onEnemyDieAction;
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public virtual void SetPosition(Vector3 newPosition)
        {
            transform.localPosition = newPosition;
        }

        public virtual void ActivateEnemy()
        {
            _enemyBody.SetActive(true);
            _navMeshAgent.enabled = true;
            
            _navMeshAgent.speed = ConfigurationData.EnemyMoveSpeed;
            _navMeshAgent.stoppingDistance = ConfigurationData.EnemyAttackRangeValue;
            ChangeState(EnemyStateType.MoveToState);
        }

        public virtual void DeactivateEnemy()
        {
            _navMeshAgent.enabled = false;
            _enemyBody.SetActive(false);
        }

        public virtual void Dispose()
        {
        }

        private void Update()
        {
            if (_currentEnemyState == EnemyStateType.DieState)
                return;

            EnemyMove();

            EnemyRecharge();
        }

        /*
         *  Attack Logic
         */

        public virtual void SearchTarget()
        {
            ChangeState(EnemyStateType.MoveToState);
        }

        public virtual void MoveToTarget()
        {
            _navMeshAgent.SetDestination(playerRuntime.Player.Transform.position);
        }

        public virtual void CheckAttackDistance()
        {
            float distance = Vector3.Distance(playerRuntime.Player.Transform.position, transform.position);

            ChangeState(
                distance > ConfigurationData.EnemyAttackRangeValue
                ? EnemyStateType.MoveToState
                : EnemyStateType.AttackState
                );
        }

        public abstract void Attack();

        public virtual void Recharge()
        {
            _currentRechargeTime = 0f;
        }

        public virtual void Die()
        {
            _onEnemyDieAction?.Invoke(this);
        }
        
        /*
         *  Private
         */
        
        protected void ChangeState(EnemyStateType stateTo)
        {
            _currentEnemyState = stateTo;
            
            switch (stateTo)
            {
                case EnemyStateType.SearchState:
                    SearchTarget();
                    break;
                case EnemyStateType.MoveToState:
                    MoveToTarget();
                    break;
                case EnemyStateType.TargetReached:
                    CheckAttackDistance();
                    break;
                case EnemyStateType.AttackState:
                    Attack();
                    break;
                case EnemyStateType.RechargeState:
                    Recharge();
                    break;
                case EnemyStateType.DieState:
                    Die();
                    break;
                case EnemyStateType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(stateTo), stateTo, null);
            }
        }

        private void EnemyMove()
        {
            if (_currentEnemyState != EnemyStateType.MoveToState)
                return;
            
            _navMeshAgent.SetDestination(playerRuntime.Player.Transform.position);

            if (!IsEnemyReachedTarget())
                return;
            
            ChangeState(EnemyStateType.TargetReached);
        }

        private void EnemyRecharge()
        {
            if (_currentEnemyState != EnemyStateType.RechargeState)
                return;

            if (_currentRechargeTime < ConfigurationData.EnemyAttackIntervalValue)
            {
                _currentRechargeTime += Time.deltaTime;
            }
            else
            {
                ChangeState(EnemyStateType.MoveToState);
            }
        }

        private bool IsEnemyReachedTarget()
        {
            return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance;
        }
    }
}