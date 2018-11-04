using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorrowMyAngel.Client;
using BorrowMyAngel.Server;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BorrowMyAngel.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagingScreen : ContentPage
	{
        private string _role;
        private Color _origSendBtnColor;

		public MessagingScreen (string role)
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            //Get the original color of the button for later use and set it to
            //  gray and transparent input so the user can't send empty messages
            _origSendBtnColor = btnSend.BackgroundColor;
            btnSend.BackgroundColor = Color.LightGray;
            btnSend.InputTransparent = true;
            //Set up the listener for the message entry text changed property.
            //  We'll use this so we can enable/disable the send button
            entryMessage.TextChanged += (sender, e) => {
                if (string.IsNullOrEmpty(entryMessage.Text))
                {
                    //There is no text in the message entry so don't allow the
                    //  user to use the send button
                    btnSend.BackgroundColor = Color.LightGray;
                    btnSend.InputTransparent = true;
                }
                else
                {
                    btnSend.BackgroundColor = _origSendBtnColor;
                    btnSend.InputTransparent = false;
                }
            };

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnSend.WidthRequest = btnSend.Width + 20;
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

            var message = (_role.Equals("client") ? "Person In Need:" : "Angel:") + entryMessage.Text;

            if (_role.Equals("client"))
                TCPClient.SendMessage(message);
            else
                TCPServer.SendMessage(message);

            //Remove the text from the entry field
            entryMessage.Text = "";
        }

        async void CreateMessageBox(string message)
        {
            var messageParts = message.Split(':');

            StackLayout layout = new StackLayout();
            layout.Padding = new Thickness(15);
            layout.Margin = new Thickness(10);
            layout.WidthRequest = (scrollMessages.Width / 3) * 2;

            if (messageParts[0].Equals("You"))
            {
                layout.BackgroundColor = Color.Cyan;
                layout.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                layout.BackgroundColor = Color.FromHex("#2ecc71");
                layout.HorizontalOptions = LayoutOptions.Start;
            }

            Label lblStamp = new Label();
            lblStamp.Text = messageParts[0] + " @ " + 
                DateTime.Now.ToShortDateString() + " " +  
                DateTime.Now.ToShortTimeString();
            lblStamp.VerticalOptions = LayoutOptions.Start;
            lblStamp.FontSize = 10;
            lblStamp.TextColor = Color.Gray;

            layout.Children.Add(lblStamp);

            Label lblMessage = new Label();
            lblMessage.Text = messageParts[1];
            lblMessage.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblMessage.VerticalTextAlignment = TextAlignment.Center;

            layout.Children.Add(lblMessage);

            layoutMessages.Children.Add(layout);

            //Add to the scroll view so it will automaticall scroll down with
            //  the messages. We need two of them because the first one won't 
            //  scroll all the way down for some reason...
            await scrollMessages.ScrollToAsync(layout, ScrollToPosition.MakeVisible, true);
            await scrollMessages.ScrollToAsync(layout, ScrollToPosition.MakeVisible, true);
        }
	}
}