using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerInputService
{
    public interface IPlayerInputService
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
        bool IsAttackButtonUp();
        bool IsUltButtonUp();
    }
}