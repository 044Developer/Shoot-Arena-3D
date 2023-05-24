using UnityEngine;
using UnityEngine.AI;

namespace ShootArena.Infrastructure.Core.Enemies.View
{
    public interface IEnemyView
    {
        public NavMeshAgent NavMeshAgent { get; }
        public GameObject EnemyBody { get; }
        public Transform EnemyTransform { get; }
    }
}