using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel
{
    [Serializable]
    public class MainMenuViewModel : IMainMenuViewModel
    {
        [Header("Buttons")]
        [SerializeField] private Button _playButton = null;
        [SerializeField] private Button _gitHubButton = null;
        [SerializeField] private Button _linkedInButton = null;
        [SerializeField] private Button _telegramButton = null;

        [Header("Animation")]
        [SerializeField] private RectTransform _logoTextRect = null;
        [SerializeField] private Vector2 _startAnimationValue = new Vector2();
        [SerializeField] private Vector2 _endAnimationValue = new Vector2();
        [SerializeField] private float _logoAnimationDuration = 1f;
        [SerializeField] private Vector2 _logoPunchVibrationValue = new Vector2();
        [SerializeField] private float _logoPunchVibrationDuration = 0.5f;

        public Button PlayButton => _playButton;
        public Button GitHubButton => _gitHubButton;
        public Button LinkedInButton => _linkedInButton;
        public Button TelegramButton => _telegramButton;
        public RectTransform LogoTextRect => _logoTextRect;
        public Vector2 StartAnimationValue => _startAnimationValue;
        public Vector2 EndAnimationValue => _endAnimationValue;
        public float LogoAnimationDuration => _logoAnimationDuration;
        public Vector2 LogoPunchVibrationValue => _logoPunchVibrationValue;
        public float LogoPunchVibrationDuration => _logoPunchVibrationDuration;
    }
}