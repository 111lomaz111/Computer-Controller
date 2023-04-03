﻿using MobileClient.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;

            InitializeComponent();
        }
    }
}