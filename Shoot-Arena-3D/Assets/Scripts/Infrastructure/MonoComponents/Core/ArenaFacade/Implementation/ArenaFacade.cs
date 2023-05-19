using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.Core.ArenaFacade.Implementation
{
    public class ArenaFacade : MonoBehaviour, IArenaFacade
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
        
        public class Factory : PlaceholderFactory<ArenaFacade>
        {
        }
    }
}