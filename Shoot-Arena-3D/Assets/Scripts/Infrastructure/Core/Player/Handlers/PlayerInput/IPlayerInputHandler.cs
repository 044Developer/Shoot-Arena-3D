using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput
{
    public interface IPlayerInputHandler
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
        bool IsAttackButtonUp();
        bool IsUltButtonUp();
    }
}