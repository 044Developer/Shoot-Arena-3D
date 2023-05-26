using ShootArena.Infrastructure.Core.Player.View;
using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Model
{
    public interface IPlayer
    {
        public IPlayerView View { get; }
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
        bool IsPlayerGrounded();
        void ReceiveDamage(float damageValue);
        void LoseUltPoints(float loseValue);
    }
}