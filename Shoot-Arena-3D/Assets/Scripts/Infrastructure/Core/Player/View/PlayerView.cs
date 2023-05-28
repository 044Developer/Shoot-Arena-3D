using System;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.View
{
    [Serializable]
    public class PlayerView : IPlayerView
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private CharacterController _characterController = null;
        [SerializeField] private Transform _shootPoint = null;

        public Transform Transform => _transform;
        public CharacterController CharacterController => _characterController;
        public Transform ShootPoint => _shootPoint;
    }
}