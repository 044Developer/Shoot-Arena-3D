using ShootArena.Infrastructure.Core.Arena;
using ShootArena.Infrastructure.Core.Arena.Implementation;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.EnvironmentSpawn.Implementation
{
    public class EnvironmentSpawnService : IEnvironmentSpawnService
    {
        private readonly ArenaFacade.Factory _arenaFactory = null;
        private readonly IDynamicPrefabFacade _dynamicPrefabFacade = null;
        private readonly ILevelAreaRuntimeData _levelAreaRuntimeData = null;
        private readonly ISpawnPositionService _spawnPositionService = null;

        public EnvironmentSpawnService(
            ArenaFacade.Factory arenaFactory,
            IDynamicPrefabFacade dynamicPrefabFacade,
            ILevelAreaRuntimeData levelAreaRuntimeData,
            ISpawnPositionService spawnPositionService
        )
        {
            _arenaFactory = arenaFactory;
            _dynamicPrefabFacade = dynamicPrefabFacade;
            _levelAreaRuntimeData = levelAreaRuntimeData;
            _spawnPositionService = spawnPositionService;
        }
        
        public void InitEnvironment()
        {
            SpawnArena();
        }

        private void SpawnArena()
        {
            IArenaFacade arena = _arenaFactory.Create();
            Transform arenaParent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Arena);
            _levelAreaRuntimeData.Arena = arena;
            arena.SetParent(arenaParent);
            arena.ArenaView.NavMeshSurface.BuildNavMesh();
            
            _spawnPositionService.Initialize();
        }
    }
}