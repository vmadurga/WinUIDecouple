using Microsoft.UI.Xaml;

using WinUIDecouple.Contracts.Views;
using WinUIDecouple.ViewModels;

namespace WinUIDecouple.Views
{
    public sealed partial class ShellWindow : Window, IShellWindow
    {
        public ShellViewModel ViewModel { get; }

        public ShellWindow(ShellViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            ViewModel.Initialize(shellFrame, navigationView);
        }
    }
}
