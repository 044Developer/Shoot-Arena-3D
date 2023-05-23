using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.SplashScreen.Implementation
{
    public class SplashScreenPanel : UIViewBase
    {
        [SerializeField] private SplashScreenViewModel _viewModel = null;

        private ISplashScreenMediator _mediator = null;

        [Inject]
        public void Construct(ISplashScreenMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();
            
            _mediator.Initialize();
        }

        public override void Show()
        {
            base.Show();
            
            _mediator.Execute();
        }
    }
}