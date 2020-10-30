using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using WinUIDecouple.Contracts.Services;
using WinUIDecouple.ViewModels;

namespace WinUIDecouple.Views
{
    public sealed partial class ContentGridDetailPage : Page
    {
        public ContentGridDetailViewModel ViewModel { get; }

        public ContentGridDetailPage()
        {
            ViewModel = Ioc.Default.GetService<ContentGridDetailViewModel>();
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                var navigationService = Ioc.Default.GetService<INavigationService>();
                navigationService.GetNavigationFrame().SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
