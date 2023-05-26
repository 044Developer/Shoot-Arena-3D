using UnityEngine;

namespace ShootArena.Infrastructure.Core.Player.Handlers.PlayerInput.Implementation
{
    public class PlayerMobileInputHandler : IPlayerMobileInputHandler
    {
        private const string HORIZONTAL_INPUT = "Horizontal";
        private const string VERTICAL_INPUT = "Vertical";
        private const string HORIZONTAL_MOUSE_INPUT = "Mouse X";
        private const string VERTICAL_MOUSE_INPUT = "Mouse Y";
        private const string FIRE_INPUT = "Fire";
        private const string ULT_INPUT = "Ult";

        public Vector2 MoveAxis => ReadMoveInput();
        public Vector2 RotateAxis => ReadRotateInput();
        public bool IsAttackButtonUp() => ReadFireButton();
        public bool IsUltButtonUp() => ReadUltButton();

        private Vector2 ReadMoveInput() => 
            new Vector2(SimpleInput.GetAxis(HORIZONTAL_INPUT), SimpleInput.GetAxis(VERTICAL_INPUT));

        private Vector2 ReadRotateInput() => 
            new Vector2(SimpleInput.GetAxis(HORIZONTAL_MOUSE_INPUT), SimpleInput.GetAxis(VERTICAL_MOUSE_INPUT));

        private bool ReadFireButton() => 
            SimpleInput.GetButtonUp(FIRE_INPUT);

        private bool ReadUltButton() => 
            SimpleInput.GetButtonUp(ULT_INPUT);
    }
}