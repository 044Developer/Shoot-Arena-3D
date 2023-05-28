using ShootArena.Infrastructure.Core.Arena.View;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Arena
{
    public interface IArenaFacade
    {
        public IArenaView ArenaView { get; }
        public void SetParent(Transform parent);
    }
}