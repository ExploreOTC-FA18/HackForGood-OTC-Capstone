using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BorrowMyAngel.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //When the page loads let's find out what the size of the banner
            //  should be. We want it to always be 1/16th of the current screen
            //  size.
            banner.HeightRequest = DeviceDisplay.ScreenMetrics.Height / 16;
        }
    }
}
