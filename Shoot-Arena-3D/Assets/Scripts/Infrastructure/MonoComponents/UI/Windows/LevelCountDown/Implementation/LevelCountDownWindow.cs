using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.LevelCountDown.Implementation
{
    public class LevelCountDownWindow : UIViewBase
    {
        [SerializeField] private LevelCountDownViewModel _viewModel = null;

        private ILevelCountDownMediator _mediator = null;

        [Inject]
        public void Construct(ILevelCountDownMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();
            
            _mediator.SetUpWindow();
        }

        public override void Show()
        {
            base.Show();
            
            _mediator.OpenWindow();
        }
    }
}