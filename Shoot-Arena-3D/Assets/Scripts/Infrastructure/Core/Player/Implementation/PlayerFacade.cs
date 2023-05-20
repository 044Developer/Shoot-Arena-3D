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

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);   
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}