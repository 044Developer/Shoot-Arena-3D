using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Implementation
{
    public class HudPanel : UIViewBase
    {
        [SerializeField] private HudViewModel _viewModel = null;

        private IHudMediator _mediator = null;

        [Inject]
        public void Construct(IHudMediator mediator)
        {
            _mediator = mediator;
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
            _viewModel.FireButton.onClick.AddListener(_mediator.OnFireButtonClick);
            _viewModel.UltButton.onClick.AddListener(_mediator.OnUltButtonClick);
        }

        private void DisposeButtons()
        {
            _viewModel.FireButton.onClick.RemoveListener(_mediator.OnFireButtonClick);
            _viewModel.UltButton.onClick.RemoveListener(_mediator.OnUltButtonClick);
        }
    }
}