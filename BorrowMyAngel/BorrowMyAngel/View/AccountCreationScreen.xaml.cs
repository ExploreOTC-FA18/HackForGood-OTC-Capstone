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
    public partial class AccountCreationScreen : ContentPage
    {
       
        private List<string> _genderOptions = new List<string>();
        private List<string> _stateOptions = new List<string>();
		public AccountCreationScreen ()
		{
			InitializeComponent ();

            _genderOptions.Add("Male");
            _genderOptions.Add("Female");
            _genderOptions.Add("Non-binary");
            _genderOptions.Add("Don't wish to specify");

            genderPicker.ItemsSource = _genderOptions;

            string[] states = {"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN",
                "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV",
                "WY"};

            _stateOptions.AddRange(states);

            statePicker.ItemsSource = _stateOptions;

		}
	}
}