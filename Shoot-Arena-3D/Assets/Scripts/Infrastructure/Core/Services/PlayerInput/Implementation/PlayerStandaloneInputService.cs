using UnityEngine;

namespace ShootArena.Infrastructure.Core.Services.PlayerInput.Implementation
{
    public class PlayerStandaloneInputService : IPlayerStandaloneInputService
    {
        private const string HORIZONTAL_INPUT = "Horizontal";
        private const string VERTICAL_INPUT = "Vertical";
        private const string HORIZONTAL_MOUSE_INPUT = "Mouse X";
        private const string VERTICAL_MOUSE_INPUT = "Mouse Y";

        public Vector2 MoveAxis => ReadMoveInput();
        public Vector2 RotateAxis => ReadRotateInput();
        public bool IsAttackButtonUp() => ReadFireButton();

        public bool IsUltButtonUp() => ReadUltButton();
        
        private Vector2 ReadMoveInput() => 
            new Vector2(Input.GetAxis(HORIZONTAL_INPUT), Input.GetAxis(VERTICAL_INPUT));

        private Vector2 ReadRotateInput() => 
            new Vector2(Input.GetAxis(HORIZONTAL_MOUSE_INPUT), Input.GetAxis(VERTICAL_MOUSE_INPUT));

        private bool ReadFireButton() => 
            false;

        private bool ReadUltButton() => 
            false;
    }
}