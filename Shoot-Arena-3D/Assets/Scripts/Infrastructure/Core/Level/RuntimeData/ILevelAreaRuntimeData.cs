using ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade;

namespace ShootArena.Infrastructure.Core.Level.RuntimeData
{
    public interface ILevelAreaRuntimeData
    {
        IArenaFacade Arena { get; set; }
    }
}