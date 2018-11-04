using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowMyAngel.Client;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BorrowMyAngel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionScreen : ContentPage
    {
        private double _origCircleScale;
        private double _endScale;

        public ConnectionScreen()
        {
            InitializeComponent();
            var halfOfScreenWidth = (int)(DeviceDisplay.ScreenMetrics.Width / DeviceDisplay.ScreenMetrics.Density) / 2;
            btnWaiting.CornerRadius = halfOfScreenWidth / 2;

            AbsoluteLayout.SetLayoutBounds(btnWaiting, new Rectangle(0.5, 0.5, halfOfScreenWidth, halfOfScreenWidth));
            AbsoluteLayout.SetLayoutBounds(lblWaiting, new Rectangle(0.5, 0.5, halfOfScreenWidth - 20, halfOfScreenWidth));

            NavigationPage.SetHasNavigationBar(this, false);

            TCPClient.Start();
            TCPClient.ReceivedMessage += (obj) => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if ((obj as string).Equals("!ACCEPT"))
                    {
                        Navigation.PushAsync(new MessagingScreen("client"));
                    }
                    else
                    {
                        //TODO Tell the client that there's no angels
                        Navigation.PopAsync();
                    }
                });
            };

            _origCircleScale = btnWaiting.Scale;
            _endScale = _origCircleScale + 0.5;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromMilliseconds(1), Update);
        }

        private bool Update()
        {
            //Check to see the state of the waiting circle
            if (btnWaiting.Scale <= _origCircleScale)
            {
                btnWaiting.ScaleTo(_endScale, 2000);
            } 
            else if (btnWaiting.Scale >= _endScale)
            {
                btnWaiting.ScaleTo(_origCircleScale, 3000);
            }
            //Return true so the update keeps going
            return true;
        }
    }
}