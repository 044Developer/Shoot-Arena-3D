using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Loose.Implementation
{
    public class LooseWindow : UIViewBase
    {
        [SerializeField] private LooseViewModel _viewModel = null;

        private ILooseMediator _mediator = null;

        [Inject]
        public void Construct(ILooseMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeButtons();
        }

        public override void Dispose()
        {
            base.Dispose();
            
            DisposeButtons();
        }

        private void InitializeButtons()
        {
            _viewModel.RestartButton.onClick.AddListener(_mediator.OnRestartButtonClicked);
            _viewModel.ExitButton.onClick.AddListener(_mediator.OnExitButtonClicked);
        }

        private void DisposeButtons()
        {
            _viewModel.RestartButton.onClick.RemoveListener(_mediator.OnRestartButtonClicked);
            _viewModel.ExitButton.onClick.RemoveListener(_mediator.OnExitButtonClicked);
        }
    }
}