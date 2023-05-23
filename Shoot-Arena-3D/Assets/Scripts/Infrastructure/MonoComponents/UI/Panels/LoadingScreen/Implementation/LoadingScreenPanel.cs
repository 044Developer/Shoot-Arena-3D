using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.LoadingScreen.Implementation
{
    public class LoadingScreenPanel : UIViewBase
    {
        [SerializeField] private LoadingScreenViewModel _viewModel = null;

        private ILoadingScreenMediator _mediator = null;

        [Inject]
        public void Construct(ILoadingScreenMediator mediator)
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