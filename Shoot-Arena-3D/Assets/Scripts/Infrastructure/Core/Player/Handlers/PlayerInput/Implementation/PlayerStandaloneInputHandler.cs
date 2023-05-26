using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput.Implementation
{
    public class PlayerStandaloneInputHandler : IPlayerStandaloneInputHandler
    {
        private const string HORIZONTAL_INPUT = "Horizontal";
        private const string VERTICAL_INPUT = "Vertical";
        private const string HORIZONTAL_MOUSE_INPUT = "Mouse X";
        private const string VERTICAL_MOUSE_INPUT = "Mouse Y";
        private const int FIRE_BUTTON_INPUT = 0;
        private const int ULT_BUTTON_INPUT = 1;

        public Vector2 MoveAxis => ReadMoveInput();
        public Vector2 RotateAxis => ReadRotateInput();
        public bool IsAttackButtonUp() => ReadFireButton();

        public bool IsUltButtonUp() => ReadUltButton();
        
        private Vector2 ReadMoveInput() => 
            new Vector2(Input.GetAxis(HORIZONTAL_INPUT), Input.GetAxis(VERTICAL_INPUT));

        private Vector2 ReadRotateInput() => 
            new Vector2(Input.GetAxis(HORIZONTAL_MOUSE_INPUT), Input.GetAxis(VERTICAL_MOUSE_INPUT));

        private bool ReadFireButton() =>
            Input.GetMouseButtonDown(FIRE_BUTTON_INPUT);

        private bool ReadUltButton() => 
            Input.GetMouseButtonDown(ULT_BUTTON_INPUT);
    }
}