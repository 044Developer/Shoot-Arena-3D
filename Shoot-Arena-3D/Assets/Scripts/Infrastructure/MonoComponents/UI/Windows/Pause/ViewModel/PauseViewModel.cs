using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.ViewModel
{
    [Serializable]
    public class PauseViewModel : IPauseViewModel
    {
        [Header("Buttons")]
        [SerializeField] private Button _resumeButton = null;
        [SerializeField] private Button _exitButton = null;
        
        public Button ResumeButton => _resumeButton;
        public Button ExitButton => _exitButton;
    }
}