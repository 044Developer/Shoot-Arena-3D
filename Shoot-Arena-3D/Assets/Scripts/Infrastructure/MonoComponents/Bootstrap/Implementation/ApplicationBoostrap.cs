using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.Bootstrap.Implementation
{
    public class ApplicationBoostrap : MonoBehaviour
    {
        private IGame _game = null;
        
        [Inject]
        public void Construct(IGame game)
        {
            _game = game;
        }

        private void Awake()
        {
            _game.StartApplication();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                _game.PauseApplication();
            }
            else
            {
                _game.ResumeApplication();
            }
        }

        private void OnApplicationQuit()
        {
            _game.QuitApplication();
        }
    }
}

