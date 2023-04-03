using MobileClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoundControllerPage : ContentPage
    {
        private MainPageViewModel _viewModel;
        public SoundControllerPage()
        {
            InitializeComponent();
        }

        public void Set()
        {

        }

        private void VolumeDown(object sender, EventArgs e)
        {

        }
        private void VolumeUp(object sender, EventArgs e)
        {

        }
    }
}