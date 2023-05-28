using ShootArena.Infrastructure.MonoComponents.UI.Base;
using UnityEngine;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.ViewModel
{
    public interface ILoadingScreenViewModel : IUIViewModel
    {
        public RectTransform ProgressBarBackRect { get; }
        public RectTransform ProgressBarRect { get; }
        public float LoadingDuration { get; }
    }
}