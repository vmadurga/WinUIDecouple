using System;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUIDecouple.ViewModels
{
    public class WebViewViewModel : ObservableRecipient
    {
        // TODO WTS: Set the URI of the page to show by default
        private const string DefaultUrl = "https://docs.microsoft.com/windows/apps/";

        private Uri _source;
        private bool _isLoading;
        private bool _isShowingFailedMessage;
        private Visibility _isLoadingVisibility;
        private Visibility _failedMesageVisibility;
        private ICommand _openInBrowserCommand;
        private ICommand _navigationCompletedCommand;

        public Uri Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                if (value)
                {
                    IsShowingFailedMessage = false;
                }

                SetProperty(ref _isLoading, value);
                IsLoadingVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsLoadingVisibility
        {
            get { return _isLoadingVisibility; }
            set { SetProperty(ref _isLoadingVisibility, value); }
        }

        public bool IsShowingFailedMessage
        {
            get
            {
                return _isShowingFailedMessage;
            }

            set
            {
                if (value)
                {
                    IsLoading = false;
                }

                SetProperty(ref _isShowingFailedMessage, value);
                FailedMesageVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility FailedMesageVisibility
        {
            get { return _failedMesageVisibility; }
            set { SetProperty(ref _failedMesageVisibility, value); }
        }

        public ICommand OpenInBrowserCommand => _openInBrowserCommand ?? (_openInBrowserCommand = new RelayCommand(async
            () => await Windows.System.Launcher.LaunchUriAsync(Source)));

        public ICommand NavigationCompletedCommand => _navigationCompletedCommand ?? (_navigationCompletedCommand = new RelayCommand<WebView2NavigationCompletedEventArgs>(OnNavigationCompleted));

        public WebViewViewModel()
        {
            IsLoading = true;
            Source = new Uri(DefaultUrl);
        }

        private void OnNavigationCompleted(WebView2NavigationCompletedEventArgs args)
        {
            IsLoading = false;
            if (args.WebErrorStatus != default)
            {
                // Use `e.WebErrorStatus` to vary the displayed message based on the error reason
                IsShowingFailedMessage = true;
            }
        }
    }
}
