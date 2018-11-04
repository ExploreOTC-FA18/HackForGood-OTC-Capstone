using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        void SubmitClicked(object sender, System.EventArgs e)
        {
            if (email.Text.ToLower().Equals("angel@hotmail.com") && password.Text.ToLower().Equals("password"))
            {
                Navigation.PushAsync(new WaitingForClients());
            }
        }
    }
}