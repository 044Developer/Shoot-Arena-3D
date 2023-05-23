using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel
{
    [Serializable]
    public class LooseViewModel : ILooseViewModel
    {
        [Header("Buttons")]
        [SerializeField] private Button _restartButton = null;
        [SerializeField] private Button _exitButton = null;

        public Button RestartButton => _restartButton;
        public Button ExitButton => _exitButton;
    }
}