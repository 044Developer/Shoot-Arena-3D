using System;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.ViewModel
{
    [Serializable]
    public class SplashScreenViewModel : ISplashScreenViewModel
    {
        [Header("Settings")]
        [SerializeField] private float _screenShowDuration = 3f;

        public float SplashScreenDuration => _screenShowDuration;
    }
}