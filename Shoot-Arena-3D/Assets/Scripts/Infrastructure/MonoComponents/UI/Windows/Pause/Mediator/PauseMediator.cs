using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.ViewModel;

namespace ShootArena.Infrastructure.MonoComponents.UI.Windows.Pause.Mediator
{
    public class PauseMediator : IPauseMediator
    {
        private IPauseViewModel _viewModel = null;
        
        public void SetModel(IUIViewModel viewModel)
        {
            _viewModel = viewModel as IPauseViewModel;
        }

        public void OnResumeButtonClicked()
        {
        }

        public void OnExitButtonClicked()
        {
        }
    }
}