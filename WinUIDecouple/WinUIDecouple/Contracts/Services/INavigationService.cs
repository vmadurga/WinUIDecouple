using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace WinUIDecouple.Contracts.Services
{
    public interface INavigationService
    {
        event NavigatedEventHandler Navigated;

        bool CanGoBack { get; }

        bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false);

        void GoBack();

        void SetNavigationFrame(Frame frame);
    }
}
