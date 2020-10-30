using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

using WinUIDecouple.ViewModels;

namespace WinUIDecouple.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; }

        public ContentGridPage()
        {
            ViewModel = Ioc.Default.GetService<ContentGridViewModel>();
            InitializeComponent();
        }
    }
}
