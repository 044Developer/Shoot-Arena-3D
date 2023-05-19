using ShootArena.Infrastructure.Core.Level.RuntimeData;
using ShootArena.Infrastructure.Core.Services.EnemySpawn;
using ShootArena.Infrastructure.Core.Services.EnvironmentSpawn;
using ShootArena.Infrastructure.Core.Services.Initialize;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Builders.Level
{
    public interface ILevelBuilder
    {
        
    }
    
    public class LevelBuilder : ILevelBuilder, IInitializable, ITickable
    {
        private readonly ILevelInitializeService _initializeService = null;
        private readonly ILevelTimingRuntimeData _timingRuntimeData = null;
        private readonly IEnemySpawnService _enemySpawnService = null;
        private readonly IEnvironmentSpawnService _environmentSpawnService = null;

        public LevelBuilder(
            ILevelInitializeService initializeService,
            ILevelTimingRuntimeData timingRuntimeData,
            IEnemySpawnService enemySpawnService,
            IEnvironmentSpawnService environmentSpawnService
        )
        {
            _initializeService = initializeService;
            _timingRuntimeData = timingRuntimeData;
            _enemySpawnService = enemySpawnService;
            _environmentSpawnService = environmentSpawnService;
        }
        
        public void Initialize()
        {
            _enemySpawnService.SetUp();
            _timingRuntimeData.IsLevelPaused = true;
            _timingRuntimeData.CurrentRespawnRate = 5;
            _initializeService.ReadLevelScenario();
            _environmentSpawnService.InitEnvironment();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _timingRuntimeData.IsLevelPaused = false;
            }
        }
    }
}