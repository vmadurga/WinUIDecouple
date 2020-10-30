using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using WinUIDecouple.ViewModels;

namespace WinUIDecouple.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; }

        public WebViewPage()
        {
            ViewModel = Ioc.Default.GetService<WebViewViewModel>();
            InitializeComponent();
        }

        private void Button_OnBrowserBack(object sender, RoutedEventArgs e)
        {
            webView.GoBack();
        }

        private void Button_OnBrowserForward(object sender, RoutedEventArgs e)
        {
            webView.GoForward();
        }

        private void Button_OnReload(object sender, RoutedEventArgs e)
        {
            webView.Reload();
        }

        private void Hypenlink_OnReload(object sender, RoutedEventArgs e)
        {
            webView.Reload();
        }
    }
}
