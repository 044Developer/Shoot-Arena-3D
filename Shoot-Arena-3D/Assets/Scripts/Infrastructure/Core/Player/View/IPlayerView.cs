using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.View
{
    public interface IPlayerView
    {
        public Transform Transform { get; }
        public CharacterController CharacterController { get; }
        public Transform ShootPoint { get; }
    }
}