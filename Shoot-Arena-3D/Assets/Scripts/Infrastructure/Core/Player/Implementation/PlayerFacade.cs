using ShootArena.Infrastructure.Core.Player.Model;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Player.Implementation
{
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        [Inject]
        public void Construct()
        {
            
        }
        
        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}