using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Model
{
    public interface IPlayer
    {
        Transform Transform { get; }
        CharacterController CharacterController { get; }
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
    }
}