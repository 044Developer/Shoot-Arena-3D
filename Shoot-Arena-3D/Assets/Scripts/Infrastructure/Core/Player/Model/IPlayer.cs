using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Model
{
    public interface IPlayer
    {
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
    }
}