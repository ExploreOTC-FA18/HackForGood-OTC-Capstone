using System;
using Xamarin.Forms;

namespace BorrowMyAngel.Interfaces
{
    public class TextWrapButton : Button
    {
        public static BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(TextWrapButton), default(Thickness), defaultBindingMode: BindingMode.OneWay);
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public TextWrapButton()
        {
        }
    }
}
