using System;
using UnityEngine;
using UnityEngine.AI;

namespace ShootArena.Infrastructure.Core.Enemies.View
{
    [Serializable]
    public class EnemyView : IEnemyView
    {
        [SerializeField] private NavMeshAgent _navMeshAgent = null;
        [SerializeField] private GameObject _enemyBody = null;
        [SerializeField] private Transform _enemyTransform = null;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public GameObject EnemyBody => _enemyBody;
        public Transform EnemyTransform => _enemyTransform;
    }
}