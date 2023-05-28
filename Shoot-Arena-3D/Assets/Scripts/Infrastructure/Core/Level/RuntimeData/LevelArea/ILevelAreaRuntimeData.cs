using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData.LevelArea
{
    public interface ILevelAreaRuntimeData
    {
        IArenaFacade Arena { get; set; }
    }
}