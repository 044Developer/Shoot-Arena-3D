using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.Core.Enemies.View
{
    public interface IEnemyView
    {
        public NavMeshAgent NavMeshAgent { get; }
        public Transform EnemyTransform { get; }
        public Transform HealthBarTransform { get; }
        public Image HealthBarSliderImage { get; }
    }
}