using UnityEngine;
using UnityEngine.AI;

namespace ShootArena.Infrastructure.Core.Enemies.View
{
    public interface IEnemyView
    {
        public NavMeshAgent NavMeshAgent { get; }
        public Transform EnemyTransform { get; }
    }
}