using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel
{
    [Serializable]
    public class LooseViewModel : ILooseViewModel
    {
        [Header("Stats")]
        [SerializeField] private TextMeshProUGUI _totalKillText = null;
        [SerializeField] private TextMeshProUGUI _totalTimeText = null;
        
        [Header("Buttons")]
        [SerializeField] private Button _restartButton = null;
        [SerializeField] private Button _exitButton = null;
        
        public TextMeshProUGUI TotalKillText => _totalKillText;
        public TextMeshProUGUI TotalTimeText => _totalTimeText;
        public Button RestartButton => _restartButton;
        public Button ExitButton => _exitButton;
    }
}