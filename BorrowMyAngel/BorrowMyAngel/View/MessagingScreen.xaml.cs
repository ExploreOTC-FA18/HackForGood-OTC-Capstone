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

            _role = role;

            if (_role.Equals("client"))
            {
                TCPClient.ReceivedMessage = MessageReceived;
            }
            else
            {
                TCPServer.MessageReceived = MessageReceived;
            }
		}

        private void MessageReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
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