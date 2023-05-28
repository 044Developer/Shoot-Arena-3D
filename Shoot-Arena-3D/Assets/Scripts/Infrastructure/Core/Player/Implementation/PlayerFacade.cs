using ShootArena.Infrastructure.Core.Player.Handlers.PlayerHealth;
using ShootArena.Infrastructure.Core.Player.Handlers.PlayerUlt;
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
        private IPlayerUltHandler _playerUltHandler = null;
        
        public IPlayerView View => _view;

        [Inject]
        public void Construct(
            IPlayerHealthHandler playerHealthHandler,
            IPlayerUltHandler playerUltHandler)
        {
            _playerHealthHandler = playerHealthHandler;
            _playerUltHandler = playerUltHandler;
        }

        public void SetParent(Transform parent) => 
            transform.SetParent(parent);

        public void SetPosition(Vector3 position) =>
            transform.position = position;

        public bool IsPlayerGrounded() => 
            transform.position.y > -1;

        public void ReceiveDamage(float damageValue) => 
            _playerHealthHandler.ReceiveDamage(damageValue);

        public void LoseUltPoints(float loseValue) => 
            _playerUltHandler.DecreaseUltPoints(loseValue);

        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}