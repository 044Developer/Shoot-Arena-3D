using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.Core.Enemies.View
{
    [Serializable]
    public class EnemyView : IEnemyView
    {
        [SerializeField] private NavMeshAgent _navMeshAgent = null;
        [SerializeField] private Transform _enemyTransform = null;

        [Header("HealthBar")]
        [SerializeField] private Transform _healthBarTransform = null;
        [SerializeField] private Image _healthBarSliderImage = null;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Transform EnemyTransform => _enemyTransform;
        public Transform HealthBarTransform => _healthBarTransform;
        public Image HealthBarSliderImage => _healthBarSliderImage;
    }
}