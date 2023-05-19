using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsContainer.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Core
{
    [CreateAssetMenu(menuName = "Static Data/Core/Prefab Containers", fileName = "Core_Prefab_Container")]
    public class CorePrefabsContainer : ScriptableObject
    {
        [Header("Container")]
        [SerializeField] private DynamicPrefabsContainer _dynamicPrefabsContainer = null;

        [Header("Arena")]
        [SerializeField] private GameObject _arenaPrefab = null;
        
        [Header("Enemies")]
        [SerializeField] private MeleeEnemy _meleeEnemy = null;
        [SerializeField] private RangeEnemy _rangedEnemy = null;

        public DynamicPrefabsContainer DynamicPrefabsContainer => _dynamicPrefabsContainer;
        public GameObject ArenaPrefab => _arenaPrefab;
        public MeleeEnemy MeleeEnemy => _meleeEnemy;
        public RangeEnemy RangedEnemy => _rangedEnemy;
    }
}