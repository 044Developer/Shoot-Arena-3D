using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerInputService.Implementation
{
    public interface IPlayerMobileInputService : IPlayerInputService
    {
    }

    public interface IPlayerStandaloneInputService : IPlayerInputService
    {
    }

    public class PlayerMobileInputService : IPlayerMobileInputService
    {
        public Vector2 MoveAxis { get; }
        public Vector2 RotateAxis { get; }
        public bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }

        public bool IsUltButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }

    public class PlayerStandaloneInputService : IPlayerStandaloneInputService
    {
        public Vector2 MoveAxis { get; }
        public Vector2 RotateAxis { get; }
        public bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }

        public bool IsUltButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}