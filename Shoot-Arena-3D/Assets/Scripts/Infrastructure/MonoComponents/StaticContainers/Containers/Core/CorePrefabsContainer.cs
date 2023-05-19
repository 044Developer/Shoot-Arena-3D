using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Implementation;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Core
{
    [CreateAssetMenu(menuName = "Static Data/Core/Prefab Containers", fileName = "Core_Prefab_Container")]
    public class CorePrefabsContainer : ScriptableObject
    {
        [Header("Container")]
        [SerializeField] private DynamicPrefabsFacade _dynamicPrefabsFacade = null;

        [Header("Arena")]
        [SerializeField] private ArenaFacade _arenaFacade = null;
        
        [Header("Enemies")]
        [SerializeField] private MeleeEnemy _meleeEnemy = null;
        [SerializeField] private RangeEnemy _rangedEnemy = null;

        public DynamicPrefabsFacade DynamicPrefabsFacade => _dynamicPrefabsFacade;
        public ArenaFacade ArenaFacade => _arenaFacade;
        public MeleeEnemy MeleeEnemy => _meleeEnemy;
        public RangeEnemy RangedEnemy => _rangedEnemy;
    }
}