using System;
using System.Collections.Generic;
using BorrowMyAngel.Server;
using Xamarin.Forms;

namespace BorrowMyAngel.View
{
    public partial class WaitingForClients : ContentPage
    {
        public WaitingForClients()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TCPServer.Start();
            TCPServer.ClientReceived += ClientReceived;
        }

        private void ClientReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //lblWaiting.IsVisible = false;
                lblWaiting.Text = "Someone in need is trying to connect. Would you like to talk to them?";
                btnAccept.IsVisible = true;
                btnDecline.IsVisible = true;
            });
        }

        void AcceptClient(object sender, System.EventArgs e)
        {
            //Display the messanger
            TCPServer.SendMessage("!ACCEPT");
            Navigation.PushAsync(new MessagingScreen("server"));
        }

        void DeclineClient(object sender, System.EventArgs e)
        {
            TCPServer.SendMessage("!DECLINE");
        }
    }
}
