using ShootArena.Infrastructure.Core.Services.Initialize;
using Zenject;

namespace ShootArena.Infrastructure.Core.Builders.Level
{
    public interface ILevelBuilder
    {
        
    }
    
    public class LevelBuilder : ILevelBuilder, IInitializable
    {
        private readonly ILevelInitializeService _initializeService = null;

        public LevelBuilder(ILevelInitializeService initializeService)
        {
            _initializeService = initializeService;
        }
        
        public void Initialize()
        {
            _initializeService.ReadLevelScenario();
        }
    }
}