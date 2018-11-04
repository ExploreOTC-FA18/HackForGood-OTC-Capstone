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
	public partial class MessagingScreen : ContentPage
	{
        private string _role;

		public MessagingScreen (string role)
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            _role = role;

            if (_role.Equals("client"))
            {
                TCPClient.ReceivedMessage = MessageReceived;
            }
            else
            {
                TCPServer.MessageReceived = MessageReceived;
                lblTitle.Text = "Person In Need";
            }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var result = await DisplayAlert("Alert",
                                           "You are about to leave the chat and " +
                                            "will not be able to return. Are you " +
                                            "sure you wish to disconnect yourself " +
                                            "and the other person?",
                                            "Yes", "No");

            if (result)
            {
                if (_role.Equals("client"))
                    TCPClient.SendMessage("!DISCONNECT");
                else
                    TCPServer.SendMessage("!DISCONNECT");

                CloseChat();
            }
        }

        //Dont allow the user to press the back button on their device. They 
        //  can only tap the one provided on the page
        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        void CloseChat()
        {
            if (_role.Equals("client"))
                TCPClient.Stop();
            else
                TCPServer.Stop();

            Navigation.PopToRootAsync();
        }

        void MessageReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (message.Equals("!DISCONNECT"))
                    CloseChat();
                else
                    //Append a message box into the scrollview
                    CreateMessageBox(message);
            });
        }

        void SendMessage(object sender, System.EventArgs e)
        {
            CreateMessageBox("You: " + entryMessage.Text);

            var message = (_role.Equals("client") ? "Person In Need: " : "Angel: ") + entryMessage.Text;

            if (_role.Equals("client"))
                TCPClient.SendMessage(message);
            else
                TCPServer.SendMessage(message);
        }

        void CreateMessageBox(string message)
        {
            StackLayout layout = new StackLayout();

            if (message.Split(':')[0].Equals("You"))
            {
                layout.BackgroundColor = Color.Cyan;
                layout.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                layout.BackgroundColor = Color.FromHex("#2ecc71");
                layout.HorizontalOptions = LayoutOptions.Start;
            }

            Label lbl = new Label();
            lbl.Text = message;

            layout.Children.Add(lbl);

            layoutMessages.Children.Insert(layoutMessages.Children.Count, layout);
        }
	}
}