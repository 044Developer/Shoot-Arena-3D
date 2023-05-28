using System;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Implementation
{
    public class DynamicPrefabsFacade : MonoBehaviour, IDynamicPrefabFacade
    {
        [Header("Root Parents")]
        [SerializeField] private Transform _arenaPrefabsRoot = null;
        [SerializeField] private Transform _enemiesPrefabsRoot = null;
        [SerializeField] private Transform _playerPrefabsRoot = null;
        [SerializeField] private Transform _bulletsPrefabsRoot = null;
        
        public Transform GetPrefabParent(DynamicPrefabRootType rootType)
        {
            switch (rootType)
            {
                case DynamicPrefabRootType.Arena:
                    return _arenaPrefabsRoot;
                case DynamicPrefabRootType.Enemies:
                    return _enemiesPrefabsRoot;
                case DynamicPrefabRootType.Player:
                    return _playerPrefabsRoot;
                case DynamicPrefabRootType.Bullets:
                    return _bulletsPrefabsRoot;
                case DynamicPrefabRootType.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(rootType), rootType, null);
            }
        }
    }
}