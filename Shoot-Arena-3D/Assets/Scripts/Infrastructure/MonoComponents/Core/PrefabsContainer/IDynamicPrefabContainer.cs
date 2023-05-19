using ShootArena.Infrastructure.MonoComponents.Core.PrefabsContainer.Data;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.Core.PrefabsContainer
{
    public interface IDynamicPrefabContainer
    {
        public Transform GetPrefabParent(DynamicPrefabRootType rootType);
    }
}