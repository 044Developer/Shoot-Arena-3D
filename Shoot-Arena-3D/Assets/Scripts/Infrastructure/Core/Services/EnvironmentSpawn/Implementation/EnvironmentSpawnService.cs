using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade;
using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation;
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

        public EnvironmentSpawnService(
            ArenaFacade.Factory arenaFactory,
            IDynamicPrefabFacade dynamicPrefabFacade,
            ILevelAreaRuntimeData levelAreaRuntimeData
        )
        {
            _arenaFactory = arenaFactory;
            _dynamicPrefabFacade = dynamicPrefabFacade;
            _levelAreaRuntimeData = levelAreaRuntimeData;
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
            arena.NavMeshSurface.BuildNavMesh();
        }
    }
}