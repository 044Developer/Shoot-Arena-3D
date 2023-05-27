using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel
{
    [Serializable]
    public class HudViewModel : IHudViewModel
    {
        [Header("Stats")]
        [SerializeField] private GameObject _statsHolder = null;
        [SerializeField] private RectTransform _playerHpProgressBackRect = null;
        [SerializeField] private RectTransform _playerHpProgressRect = null;
        [SerializeField] private RectTransform _playerUltProgressBackRect = null;
        [SerializeField] private RectTransform _playerUltProgressRect = null;

        [Header("Input")]
        [SerializeField] private GameObject _mobileInputHolder = null;
        [SerializeField] private Button _pauseButton = null;

        public GameObject StatsHolder => _statsHolder;
        public RectTransform PlayerHpProgressBackRect => _playerHpProgressBackRect;
        public RectTransform PlayerHpProgressRect => _playerHpProgressRect;
        public RectTransform PlayerUltProgressBackRect => _playerUltProgressBackRect;
        public RectTransform PlayerUltProgressRect => _playerUltProgressRect;
        public GameObject MobileInputHolder => _mobileInputHolder;
        public Button PauseButton => _pauseButton;
    }
}