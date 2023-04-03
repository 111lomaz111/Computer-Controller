using MobileClient.Interfaces;
using MobileClient.Models;
using MobileClient.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    { 
        private MainPageViewModel _viewModel;
        private IWeb _webService => DependencyService.Get<IWeb>();


        public ConnectPage()
        {
            InitializeComponent();
            ShowLoadingIndicator(false);
        }


        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Task.Run(() => _viewModel.SearchDevices());
        }



        private void ShowLoadingIndicator(bool isEnable)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                listIndicator.IsVisible = isEnable;
                listIndicator.IsRunning = isEnable;
            });
        }
    }
}