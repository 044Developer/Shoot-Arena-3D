using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation
{
    public class ArenaFacade : MonoBehaviour, IArenaFacade
    {
        [SerializeField] private MeshCollider _meshCollider = null;
        [SerializeField] private List<Transform> _arenaObstacles = null;
        [SerializeField] private NavMeshSurface _navMeshSurface = null;

        public MeshCollider MeshCollider => _meshCollider;
        public NavMeshSurface NavMeshSurface => _navMeshSurface;
        public List<Transform> ArenaObstacles => _arenaObstacles;

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
        
        public class Factory : PlaceholderFactory<ArenaFacade>
        {
        }
    }
}