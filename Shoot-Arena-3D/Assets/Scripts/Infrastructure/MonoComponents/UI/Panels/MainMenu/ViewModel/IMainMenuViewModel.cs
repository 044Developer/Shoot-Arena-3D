using ShootArena.Infrastructure.MonoComponents.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel
{
    public interface IMainMenuViewModel : IUIViewModel
    {
        public Button PlayButton { get; }
        public Button GitHubButton { get; }
        public Button LinkedInButton { get; }
        public Button TelegramButton { get; }
        public RectTransform LogoTextRect { get; }
        public Vector2 StartAnimationValue { get; }
        public Vector2 EndAnimationValue { get; }
        public float LogoAnimationDuration { get; }
        public Vector2 LogoPunchVibrationValue { get; }
        public float LogoPunchVibrationDuration { get; }
    }
}