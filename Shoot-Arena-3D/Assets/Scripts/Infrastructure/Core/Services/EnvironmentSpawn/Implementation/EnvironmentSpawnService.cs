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

        public EnvironmentSpawnService(
            ArenaFacade.Factory arenaFactory,
            IDynamicPrefabFacade dynamicPrefabFacade
            )
        {
            _arenaFactory = arenaFactory;
            _dynamicPrefabFacade = dynamicPrefabFacade;
        }
        
        public void InitEnvironment()
        {
            SpawnArena();
        }

        private void SpawnArena()
        {
            ArenaFacade arena = _arenaFactory.Create();
            Transform arenaParent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Arena);
            
            arena.SetParent(arenaParent);
        }
    }
}