using System;
using System.ComponentModel;
using BorrowMyAngel.Interfaces;
using BorrowMyAngel.iOS.Interfaces;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TextWrapButton), typeof(TextWrapButtoniOS))]
namespace BorrowMyAngel.iOS.Interfaces
{
    public class TextWrapButtoniOS : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            UpdatePadding();

            if (Control != null)
            {
                Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
                Control.TitleLabel.Lines = 0;
                Control.TitleLabel.TextAlignment = UITextAlignment.Center;
            }
        }

        private void UpdatePadding()
        {
            var element = this.Element as TextWrapButton;
            if (element != null)
            {
                this.Control.ContentEdgeInsets = new UIEdgeInsets(

                    (int)element.Padding.Top,
                    (int)element.Padding.Left,
                    (int)element.Padding.Bottom,
                    (int)element.Padding.Right
                );
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(TextWrapButton.Padding))
            {
                UpdatePadding();
            }
        }
    }
}
