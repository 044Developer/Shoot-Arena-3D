using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.ViewModel
{
    [Serializable]
    public class LevelCountDownViewModel : ILevelCountDownViewModel
    {
        [Header("Window Components")]
        [SerializeField] private Image _fadeImage = null;
        [SerializeField] private TextMeshProUGUI _counterText = null;
        [SerializeField] private RectTransform _counterRectTransform = null;

        [Header("Animation Settings")]
        [SerializeField] private float _animationDuration = 3f;
        [SerializeField] private float _fadeStartValue = 1f;
        [SerializeField] private float _fadeEndValue = 0f;

        public Image FadeImage => _fadeImage;
        public TextMeshProUGUI CounterText => _counterText;
        public RectTransform CounterRectTransform => _counterRectTransform;
        public float AnimationDuration => _animationDuration;
        public float FadeStartValue => _fadeStartValue;
        public float FadeEndValue => _fadeEndValue;
    }
}