using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.RuntimeData;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.HUD.Implementation
{
    public class HudPanel : UIViewBase
    {
        [SerializeField] private HudViewModel _viewModel = null;

        private IHudMediator _mediator = null;
        private HUDRuntimeData _hudRuntimeData = null;

        [Inject]
        public void Construct(IHudMediator mediator, IHUDRuntimeData hudRuntimeData)
        {
            _mediator = mediator;
            _mediator.SetModel(_viewModel);
            _hudRuntimeData = hudRuntimeData as HUDRuntimeData;
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeButtons();
            
            InitializeEvents();
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposeButtons();
            
            DisposeEvents();
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

        private void InitializeEvents()
        {
            _hudRuntimeData.OnHealthChanged += _mediator.OnChangeHpValue;
            _hudRuntimeData.OnStrengthChanged += _mediator.OnChangeUltValue;
        }

        private void DisposeEvents()
        {
            _hudRuntimeData.OnHealthChanged -= _mediator.OnChangeHpValue;
            _hudRuntimeData.OnStrengthChanged -= _mediator.OnChangeUltValue;
        }
    }
}