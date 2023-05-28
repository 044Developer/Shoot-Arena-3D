using ShootArena.Infrastructure.Core.Arena;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea
{
    public class LevelAreaRuntimeData : ILevelAreaRuntimeData
    {
        public IArenaFacade Arena { get; set; }
    }
}