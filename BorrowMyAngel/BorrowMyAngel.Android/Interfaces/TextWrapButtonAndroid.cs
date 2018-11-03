using Android.Content;
using BorrowMyAngel.Droid.Interfaces;
using BorrowMyAngel.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextWrapButton), typeof(TextWrapButtonAndroid))]
namespace BorrowMyAngel.Droid.Interfaces
{
    class TextWrapButtonAndroid : ButtonRenderer
    {
        public TextWrapButtonAndroid(Context context) : base(context)
        {
        }
    }
}