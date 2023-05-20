﻿using ShootArena.Infrastructure.Core.Enemies.Implementation;
using ShootArena.Infrastructure.Core.Enemies.Model;
using ShootArena.Infrastructure.Core.Player.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Implementation;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootArena.Infrastructure.MonoComponents.StaticContainers.Containers.Core
{
    [CreateAssetMenu(menuName = "Static Data/Core/Prefab Containers", fileName = "Core_Prefab_Container")]
    public class CorePrefabsContainer : ScriptableObject
    {
        [Header("Container")]
        [SerializeField] private DynamicPrefabsFacade _dynamicPrefabsFacade = null;

        [Header("Arena")]
        [SerializeField] private ArenaFacade _arenaFacade = null;

        [Header("Player")]
        [SerializeField] private PlayerFacade _playerFacade = null;
        
        [Header("Enemies")]
        [SerializeField] private MeleeEnemyFacade _meleeEnemyFacade = null;
        [SerializeField] private RangeEnemyFacade _rangedEnemyFacade = null;

        public DynamicPrefabsFacade DynamicPrefabsFacade => _dynamicPrefabsFacade;
        public ArenaFacade ArenaFacade => _arenaFacade;
        public PlayerFacade PlayerFacade => _playerFacade;
        public MeleeEnemyFacade MeleeEnemyFacade => _meleeEnemyFacade;
        public RangeEnemyFacade RangedEnemyFacade => _rangedEnemyFacade;
    }
}