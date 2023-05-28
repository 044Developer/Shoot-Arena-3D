using System;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Arena.View
{
    [Serializable]
    public class ArenaView : IArenaView
    {
        [SerializeField] private MeshCollider _meshCollider = null;
        [SerializeField] private List<Transform> _arenaObstacles = null;
        [SerializeField] private NavMeshSurface _navMeshSurface = null;
        [SerializeField] private Transform _arenaTransform = null;

        public MeshCollider MeshCollider => _meshCollider;
        public List<Transform> ArenaObstacles => _arenaObstacles;
        public NavMeshSurface NavMeshSurface => _navMeshSurface;
        public Transform ArenaTransform => _arenaTransform;
    }
}