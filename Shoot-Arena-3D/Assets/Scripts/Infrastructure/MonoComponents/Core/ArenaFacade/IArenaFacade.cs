using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade
{
    public interface IArenaFacade
    {
        public MeshCollider MeshCollider { get; }
        public NavMeshSurface NavMeshSurface { get; }
        public List<Transform> ArenaObstacles { get; }
        public void SetParent(Transform parent);
    }
}