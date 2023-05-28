using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Implementation
{
    public class PauseWindow : UIViewBase
    {
        [SerializeField] private PauseViewModel _viewModel = null;

        private IPauseMediator _mediator = null;

        [Inject]
        public void Construct(IPauseMediator mediator)
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
            _viewModel.ResumeButton.onClick.AddListener(_mediator.OnResumeButtonClicked);
            _viewModel.ExitButton.onClick.AddListener(_mediator.OnExitButtonClicked);
        }

        private void DisposeButtons()
        {
            _viewModel.ResumeButton.onClick.RemoveListener(_mediator.OnResumeButtonClicked);
            _viewModel.ExitButton.onClick.RemoveListener(_mediator.OnExitButtonClicked);
        }
    }
}