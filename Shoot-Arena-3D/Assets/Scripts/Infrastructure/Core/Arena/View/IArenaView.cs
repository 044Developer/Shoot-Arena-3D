using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Arena.View
{
    public interface IArenaView
    {
        public MeshCollider MeshCollider { get; }
        public List<Transform> ArenaObstacles { get; }
        public NavMeshSurface NavMeshSurface { get; }
        public Transform ArenaTransform { get; }
    }
}