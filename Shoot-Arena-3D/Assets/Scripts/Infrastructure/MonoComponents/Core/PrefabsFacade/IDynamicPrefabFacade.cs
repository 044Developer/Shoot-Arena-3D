using ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.PrefabsFacade
{
    public interface IDynamicPrefabFacade
    {
        public Transform GetPrefabParent(DynamicPrefabRootType rootType);
    }
}