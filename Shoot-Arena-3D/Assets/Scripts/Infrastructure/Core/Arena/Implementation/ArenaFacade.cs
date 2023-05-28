using ShootArena.Infrastructure.Core.Arena.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Arena.Implementation
{
    public class ArenaFacade : MonoBehaviour, IArenaFacade
    {
        [SerializeField] private ArenaView _view = null;

        public IArenaView ArenaView => _view;

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }
        
        public class Factory : PlaceholderFactory<ArenaFacade>
        {
        }
    }
}