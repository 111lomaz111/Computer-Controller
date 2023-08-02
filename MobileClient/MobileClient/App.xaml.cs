using System;
using Microsoft.Maui.Controls.Xaml;
using MobileClient.Services;
using MobileClient.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace MobileClient
{
    public partial class App : Application
    {
        


        public App()
        {
            InitializeComponent();

            DependencyService.Register<WebListener>();
            DependencyService.Register<RestClientService>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
