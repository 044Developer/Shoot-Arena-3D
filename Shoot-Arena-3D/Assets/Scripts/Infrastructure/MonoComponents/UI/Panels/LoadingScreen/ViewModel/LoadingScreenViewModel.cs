using System;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.ViewModel
{
    [Serializable]
    public class LoadingScreenViewModel : ILoadingScreenViewModel
    {
        [Header("Progress Bar")]
        [SerializeField] private RectTransform _progressBarBackRect = null;
        [SerializeField] private RectTransform _progressBarRect = null;

        [Header("Settings")]
        [SerializeField] private float _loadingDuration = 3f;

        public RectTransform ProgressBarBackRect => _progressBarBackRect;
        public RectTransform ProgressBarRect => _progressBarRect;
        public float LoadingDuration => _loadingDuration;
    }
}