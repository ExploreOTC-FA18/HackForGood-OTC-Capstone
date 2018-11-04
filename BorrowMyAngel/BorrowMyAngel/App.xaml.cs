using BorrowMyAngel.Client;
using BorrowMyAngel.Server;
using BorrowMyAngel.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BorrowMyAngel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            TCPClient.Stop();
            TCPServer.Stop();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
