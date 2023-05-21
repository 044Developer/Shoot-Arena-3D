using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerInput
{
    public interface IPlayerInputService
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
        bool IsAttackButtonUp();
        bool IsUltButtonUp();
    }
}