using ShootArena.Infrastructure.Core.Arena;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea
{
    public interface ILevelAreaRuntimeData
    {
        IArenaFacade Arena { get; set; }
    }
}