using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth;
using ShootArena.Infrastructure.Core.Player.Model;
using ShootArena.Infrastructure.Core.Player.View;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Player.Implementation
{
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerView _view = null;

        private IPlayerHealthHandler _playerHealthHandler = null;
        
        public IPlayerView View => _view;

        [Inject]
        public void Construct(IPlayerHealthHandler playerHealthHandler)
        {
            _playerHealthHandler = playerHealthHandler;
        }

        public void SetParent(Transform parent) => 
            transform.SetParent(parent);

        public void SetPosition(Vector3 position) =>
            transform.position = position;

        public bool IsPlayerGrounded() => 
            transform.position.y > -1;

        public void ReceiveDamage(float damageValue)
        {
            _playerHealthHandler.ReceiveDamage(damageValue);
        }

        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}