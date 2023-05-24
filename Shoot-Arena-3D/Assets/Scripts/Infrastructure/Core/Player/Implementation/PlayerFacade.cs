using ShootArena.Infrastructure.Core.Player.Model;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.Core.Player.Implementation
{
    public class PlayerFacade : MonoBehaviour, IPlayer
    {
        [SerializeField] private CharacterController _characterController = null;
        [SerializeField] private Transform _playerTransform = null;
        
        public Transform Transform => _playerTransform;
        public CharacterController CharacterController => _characterController;

        [Inject]
        public void Construct()
        {
        }

        public void SetParent(Transform parent) => 
            transform.SetParent(parent);

        public void SetPosition(Vector3 position) =>
            transform.position = position;

        public bool IsPlayerGrounded() => 
            transform.position.y > -1;

        public class Factory : PlaceholderFactory<PlayerFacade>
        {
        }
    }
}