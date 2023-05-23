using ShootArena.Infrastructure.MonoComponents.UI.Base;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Mediator;
using ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.ViewModel;
using UnityEngine;
using Zenject;

namespace ShootArena.Infrastructure.MonoComponents.UI.Panels.MainMenu.Implementation
{
    public class MainMenuPanel : UIViewBase
    {
        [SerializeField] private MainMenuViewModel _viewModel = null;

        private IMainMenuMediator _mediator = null;

        [Inject]
        public void Construct(IMainMenuMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetModel(_viewModel);
        }

        public override void Initialize()
        {
            base.Initialize();
            
            InitializeButtons();
            
            _mediator.Initialize();
        }

        public override void Show()
        {
            base.Show();
            
            _mediator.Execute();
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposeButtons();
        }

        private void InitializeButtons()
        {
            _viewModel.PlayButton.onClick.AddListener(_mediator.OnPlayButtonClicked);
            _viewModel.GitHubButton.onClick.AddListener(_mediator.OnGitHubButtonClicked);
            _viewModel.LinkedInButton.onClick.AddListener(_mediator.OnLinkedInButtonClicked);
            _viewModel.TelegramButton.onClick.AddListener(_mediator.OnTelegramButtonClicked);
        }

        private void DisposeButtons()
        {
            _viewModel.PlayButton.onClick.RemoveListener(_mediator.OnPlayButtonClicked);
            _viewModel.GitHubButton.onClick.RemoveListener(_mediator.OnGitHubButtonClicked);
            _viewModel.LinkedInButton.onClick.RemoveListener(_mediator.OnLinkedInButtonClicked);
            _viewModel.TelegramButton.onClick.RemoveListener(_mediator.OnTelegramButtonClicked);
        }
    }
}