using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowMyAngel.Client;
using BorrowMyAngel.Server;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BorrowMyAngel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginScreen : ContentPage
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Just incase the user is coming from somwhere that would have the
            //  server/client being ran let's shut that off
            TCPClient.Stop();
            TCPServer.Stop();
        }

        void SubmitClicked(object sender, System.EventArgs e)
        {
            if (email.Text.ToLower().Equals("angel@hotmail.com") && password.Text.ToLower().Equals("password"))
            {
                Navigation.PushAsync(new WaitingForClients());
            }
        }
    }
}