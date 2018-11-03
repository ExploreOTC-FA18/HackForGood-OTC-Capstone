using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BorrowMyAngel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionScreen : ContentPage
    {
        public ConnectionScreen()
        {
            InitializeComponent();
            var halfOfScreenWidth = (int)(DeviceDisplay.ScreenMetrics.Width / DeviceDisplay.ScreenMetrics.Density) / 2;
            btnWaiting.CornerRadius = halfOfScreenWidth;
            btnWaiting.HeightRequest = halfOfScreenWidth;
            btnWaiting.WidthRequest = halfOfScreenWidth;

        }
    }
}