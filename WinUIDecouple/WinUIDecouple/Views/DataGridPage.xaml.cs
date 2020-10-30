﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

using WinUIDecouple.ViewModels;

namespace WinUIDecouple.Views
{
    public sealed partial class DataGridPage : Page
    {
        public DataGridViewModel ViewModel { get; }

        public DataGridPage()
        {
            ViewModel = Ioc.Default.GetService<DataGridViewModel>();
            InitializeComponent();
        }
    }
}
