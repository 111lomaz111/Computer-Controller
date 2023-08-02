using MobileClient.ViewModels;

namespace MobileClientMAUI
{
    public partial class AppShell : Shell
    {
        private MainPageViewModel _viewModel;

        public AppShell()
        {
            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;

            InitializeComponent();
        }
    }
}