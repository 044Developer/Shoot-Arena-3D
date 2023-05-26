using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Player.Implementation;
using ShootArena.Infrastructure.Core.Player.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.SpawnPosition;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade;
using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerSpawn.Implementation
{
    public class PlayerSpawnService : IPlayerSpawnService
    {
        private readonly PlayerFacade.Factory _playerFactory = null;
        private readonly IDynamicPrefabFacade _dynamicPrefabFacade = null;
        private readonly IPlayerRuntimeData _playerRuntimeData = null;
        private readonly ISpawnPositionService _spawnPositionService = null;
        private readonly IPlayerSetUpHandler _playerSetUpHandler = null;

        public PlayerSpawnService(
            PlayerFacade.Factory playerFactory,
            IDynamicPrefabFacade dynamicPrefabFacade,
            IPlayerRuntimeData playerRuntimeData,
            ISpawnPositionService spawnPositionService,
            IPlayerSetUpHandler playerSetUpHandler
        )
        {
            _playerFactory = playerFactory;
            _dynamicPrefabFacade = dynamicPrefabFacade;
            _playerRuntimeData = playerRuntimeData;
            _spawnPositionService = spawnPositionService;
            _playerSetUpHandler = playerSetUpHandler;
        }
        
        public void SpawnPlayer()
        {
            IPlayer player = _playerFactory.Create();

            Transform playerParent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Player);
            player.SetParent(playerParent);

            Vector3 playerPosition = _spawnPositionService.GetPlayerSpawnPosition();
            player.SetPosition(playerPosition);

            _playerRuntimeData.Player = player;
            _playerSetUpHandler.SetUpPlayer();
        }

        public void RespawnPlayer()
        {
            Vector3 playerPosition = _spawnPositionService.GetPlayerSpawnPosition();
            _playerRuntimeData.Player.SetPosition(playerPosition);
            _playerRuntimeData.PlayerControlData.IsRespawning = false;
        }
    }
}