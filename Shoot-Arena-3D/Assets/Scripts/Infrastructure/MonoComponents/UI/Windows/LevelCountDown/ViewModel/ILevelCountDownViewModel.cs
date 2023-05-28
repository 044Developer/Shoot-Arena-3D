using ShootArena.Infrastructure.MonoComponents.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.ViewModel
{
    public interface ILevelCountDownViewModel : IUIViewModel
    {
        public Image FadeImage { get; }
        public TextMeshProUGUI CounterText { get; }
        public RectTransform CounterRectTransform { get; }
        public float AnimationDuration { get; }
        public float FadeStartValue { get; }
        public float FadeEndValue { get; }
    }
}