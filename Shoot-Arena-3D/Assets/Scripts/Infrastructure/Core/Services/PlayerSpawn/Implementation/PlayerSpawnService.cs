using System.Collections.Generic;
using ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerSetUp;
using ShootArena.Infrastructure.Core.Player.Implementation;
using ShootArena.Infrastructure.Core.Player.Model;
using ShootArena.Infrastructure.Core.Player.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemyRegistry;
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
        private readonly PlayerRuntimeData _playerRuntimeData = null;
        private readonly ISpawnPositionService _spawnPositionService = null;
        private readonly IPlayerSetUpHandler _playerSetUpHandler = null;
        private readonly IEnemyRegistryService _enemyRegistryService = null;
        private readonly ILevelAreaRuntimeData _levelAreaRuntimeData = null;

        public PlayerSpawnService(
            PlayerFacade.Factory playerFactory,
            IDynamicPrefabFacade dynamicPrefabFacade,
            IPlayerRuntimeData playerRuntimeData,
            ISpawnPositionService spawnPositionService,
            IPlayerSetUpHandler playerSetUpHandler,
            IEnemyRegistryService enemyRegistryService,
            ILevelAreaRuntimeData levelAreaRuntimeData
        )
        {
            _playerFactory = playerFactory;
            _dynamicPrefabFacade = dynamicPrefabFacade;
            _playerRuntimeData = playerRuntimeData as PlayerRuntimeData;
            _spawnPositionService = spawnPositionService;
            _playerSetUpHandler = playerSetUpHandler;
            _enemyRegistryService = enemyRegistryService;
            _levelAreaRuntimeData = levelAreaRuntimeData;
        }
        
        public void SpawnPlayer()
        {
            IPlayer player = _playerFactory.Create();

            Transform playerParent = _dynamicPrefabFacade.GetPrefabParent(DynamicPrefabRootType.Player);
            player.SetParent(playerParent);

            Vector3 playerPosition = _spawnPositionService.GetSpawnPositionFromNewArea();
            player.SetPosition(playerPosition);

            player.View.Transform.LookAt(_levelAreaRuntimeData.Arena.ArenaView.ArenaCenter);
            
            _playerRuntimeData.Player = player;
            _playerSetUpHandler.SetUpPlayer();
        }

        public void RespawnPlayer()
        {
            List<Transform> enemiesPositions = _enemyRegistryService.GetAllActiveEnemiesTransform();
            
            Vector3 playerPosition = _spawnPositionService.GetFarSpawnPosition(enemiesPositions);
            _playerRuntimeData.Player.SetPosition(playerPosition);

            _playerRuntimeData.Player.View.Transform.LookAt(_levelAreaRuntimeData.Arena.ArenaView.ArenaCenter);
        }
    }
}